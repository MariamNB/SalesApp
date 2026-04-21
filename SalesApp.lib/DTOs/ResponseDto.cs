using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs
{
    public class ResponseDto
    {
        public ResponseDto(bool _success = false, string _message = null!)
        {
            success = _success;
            message = _message;
        }
      
        public bool success {get; set;}
        public string message {get; set;}
        
    }
}