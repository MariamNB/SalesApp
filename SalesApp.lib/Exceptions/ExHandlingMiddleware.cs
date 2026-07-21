using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.lib.Base;

namespace SalesApp.lib.Exceptions
{
    public class ExHandlingMiddleware(RequestDelegate _next)
    {
       

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExHandlingMiddleware>>();
                var innerEx  = ex.InnerException as SqlException;
                if (innerEx != null)
                {
                    logger.LogError(innerEx, "Database error occurred.");
                    switch (innerEx.Number)
                    {
                        case 2627:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("Conflict: Duplicate entry detected.");
                            break;  
                       case 515:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Bad Request: A required field is missing.");
                            break;  
                        case 547:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Bad Request: Foreign key constraint violation.");
                            break;
                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync("An unexpected database error occurred.");
                            break;
                    }
                } 
                else
                {
                    logger.LogError(ex, "An unexpected error occurred.");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An unexpected error occurred.");
                }
            }
            catch (Exception ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLoger<ExHandlingMiddleware>>();
                logger.LogError(ex, "An unexpected error occurred.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }


    }
}