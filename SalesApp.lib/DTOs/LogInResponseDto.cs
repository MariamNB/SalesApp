using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs
{
    public class LogInResponseDto 
    {
        public LogInResponseDto(bool _success = false, string _message = null!, string token = "", string refreshToken = "")
        {
            success = _success;
            message = _message;
            Token = token;
            RefreshToken = refreshToken;
        }
      
        public bool success {get; set;}
        public string message {get; set;}
        public string Token {get; set;}
        public string RefreshToken{get; set;}
    }
}