using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionMicroservice.Models
{
    public class Account
    {
        /* public int AccountId { get; set; }
         public int CustomerId { get; set; }
         public DateTime AccountCreationDate { get; set; }
         public string AccountType { get; set; }
         public double CurrentBalance { get; set; }*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Account_Type { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AccountCreationDate { get; set; }
        public double Balance_Amount { get; set; }

    }
}

