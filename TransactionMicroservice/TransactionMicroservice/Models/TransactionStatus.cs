using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class TransactionStatus
    {
        /*public string Message { get; set; }
        public double Updated_Balance { get; set; }*/
        public int AccountId { get; set; }
        public string Message { get; set; }
        public double Source_Balance { get; set; }
        public double Destination_Balance { get; set; }
    }
}
