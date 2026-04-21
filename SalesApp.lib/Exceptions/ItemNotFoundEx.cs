using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.Exceptions
{
    public class ItemNotFoundEx(string msg) : Exception(msg)
    {
        
    }
}