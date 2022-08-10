using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Financial_Transactions
    {
        [Key]
        public int Transaction_Id { get; set; }
        public Account Account { get; set; }

        [ForeignKey("Account")]
        public int Account_Id { get; set; }

        public Counterparties Counterparty { get; set; }
        [ForeignKey("Counterparty")]
        public int Counterparty_Id { get; set; }

        public Ref_Payment_Methods Payment_Methods { get; set; }
        [ForeignKey("Payment_Methods")]
        public string Payment_Method_Code { get; set; }

        public Service Services { get; set; }
        [ForeignKey("Services")]
        public int Service_Id { get; set; }

        public Ref_Transaction_Status Transaction_Status { get; set; }
        [ForeignKey("Transaction_Status")]
        public string Transaction_Status_Code { get; set; }

        public Ref_Transaction_Types Transaction_Types { get; set; }
        [ForeignKey("Transaction_Types")]
        public string Transaction_Type_Code { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Date_of_Transaction { get; set; }

        public double Amount_of_Transaction { get; set; }

    }
}
