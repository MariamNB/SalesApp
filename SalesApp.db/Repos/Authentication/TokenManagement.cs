using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Base.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesApp.db.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Repos.Authentication
{
    public class TokenManagement (AppDbContext context, IConfiguration config): ITokenManagement
    {
        public async Task<int> AddRefreshToken(string userId, string refreshToken)
        {
            context.RefreshTokens.Add(new Entities.Identity.RefreshToken
            {
                UserId = userId,
                Token = refreshToken
            });
            return await context.SaveChangesAsync();
        }

        public string GenerateToken(List<Claim> claims)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var expairation = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: expairation,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken()
        {
            const int byteSize = 64; byte[] randomBytes = new byte[byteSize];
            using(RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        public  List<Claim> GetUserClaimsFromToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(email);
            if(token != null)
            {
                return token.Claims.ToList();

            }
            else
            {
                return [];
            }
        }

        public async Task<string> GetUserIdByRefreshToken(string refreshToken)
        {
            return (await context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.Token == refreshToken))!.UserId;
        }

        public async Task<int> UpdateRefreshToken(string userId, string refreshToken)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            if (user != null)
            {
                user.Token = refreshToken;
                return await context.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            return user != null;
        }
    }
}