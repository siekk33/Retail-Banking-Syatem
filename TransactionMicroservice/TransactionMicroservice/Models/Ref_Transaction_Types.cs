using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Ref_Transaction_Types
    {
        [Key]
        public string Transaction_Type_Code { get; set; }

        public string Transaction_Type_Description { get; set; }
    }
}
