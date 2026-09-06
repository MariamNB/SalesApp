using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Payments
{
    public class PaymentMehodDto
    {
        public required Guid Id {get;set;}
        public required string Name {get;set;}
    }
}