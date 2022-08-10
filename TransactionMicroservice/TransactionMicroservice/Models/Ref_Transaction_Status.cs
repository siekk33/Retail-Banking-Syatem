using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Ref_Transaction_Status
    {
        [Key]
        public string Transaction_Status_Code { get; set; }

        public string Transaction_Status_Description { get; set; }
    }
}
