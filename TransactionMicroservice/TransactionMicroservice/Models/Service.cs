using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionMicroservice.Models
{
    public class Service
    {
        [Key]
        public int Service_Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date_Service_Provided { get; set; }
    }
}
