using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class CustomerCreationStatus
    {
        [Key]
        public int CustomerId { get; set; }
        public string Status { get; set; }
        
    }
}
