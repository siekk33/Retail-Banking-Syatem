using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Ref_Payment_Methods
    {
        [Key]
        public string Payment_Method_Code { get; set; }
        public string Payment_Method_Name { get; set; }

    }
}
