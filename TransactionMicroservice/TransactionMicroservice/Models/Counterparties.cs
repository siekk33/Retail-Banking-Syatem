using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Counterparties
    {
        [Key]
        public int Counterparty_ID { get; set; }

        public string Counterparty_Name { get; set; }
    }
}
