using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Paymets
{
    public class PaymentMethod
    {
        [Key]
        public Guid Id {get;set;}
        public string Name {get;set;} = string.Empty;
    }
}