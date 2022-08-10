using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuleMicroservice.Models
{
    public class Rule
    {
        [Key]
        public int AccountId { get; set; }

        public double balance { get; set; }
    }
}
