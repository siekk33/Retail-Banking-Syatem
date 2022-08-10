using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Data
{
    public static class DBHelper
    {
        public static List<Counterparties> Counterparties = new List<Counterparties> {
            new Counterparties(){ Counterparty_ID = 1, Counterparty_Name = "Counterparty1"},
            new Counterparties(){ Counterparty_ID = 2, Counterparty_Name = "Counterparty2"},
            new Counterparties(){ Counterparty_ID = 3, Counterparty_Name = "Counterparty3"},
            new Counterparties(){ Counterparty_ID = 4, Counterparty_Name = "Counterparty4"},
            new Counterparties(){ Counterparty_ID = 5, Counterparty_Name = "Counterparty5"}
        };

        public static List<Ref_Payment_Methods> Payment_Methods = new List<Ref_Payment_Methods>
        {

            new Ref_Payment_Methods(){ Payment_Method_Code = "PMCode1", Payment_Method_Name = "Bank Transfer"},
            new Ref_Payment_Methods(){ Payment_Method_Code = "PMCode2", Payment_Method_Name = "Cash"},
           new Ref_Payment_Methods(){ Payment_Method_Code = "PMCode3", Payment_Method_Name = "Rupay"},
            new Ref_Payment_Methods(){ Payment_Method_Code = "PMCode4", Payment_Method_Name = "MasterCard"},
            new Ref_Payment_Methods(){ Payment_Method_Code = "PMCode5", Payment_Method_Name = "Visa"}
        };

        public static List<Service> Services = new List<Service>
        {
            new Service{ Service_Id = 1, Date_Service_Provided = new DateTime(2022,02,21)},
            new Service{ Service_Id = 1, Date_Service_Provided = new DateTime(2022,07,15)},
            new Service{ Service_Id = 1, Date_Service_Provided = new DateTime(2022,01,30)},
            new Service{ Service_Id = 1, Date_Service_Provided = new DateTime(2022,11,02)},
            new Service{ Service_Id = 1, Date_Service_Provided = new DateTime(2022,02,27)}
        };

        public static List<Ref_Transaction_Types> Transaction_Types = new List<Ref_Transaction_Types>
        {
            new Ref_Transaction_Types { Transaction_Type_Code = "T01", Transaction_Type_Description = "Adjustment"},
            new Ref_Transaction_Types { Transaction_Type_Code = "T02", Transaction_Type_Description = "Payment"},
            new Ref_Transaction_Types { Transaction_Type_Code = "T03", Transaction_Type_Description = "Refund"}
        };

        public static List<Ref_Transaction_Status> Transaction_Statuses = new List<Ref_Transaction_Status>
        {
            new Ref_Transaction_Status{ Transaction_Status_Code = "TSC01", Transaction_Status_Description = "Cancelled"},
            new Ref_Transaction_Status{ Transaction_Status_Code = "TSC02", Transaction_Status_Description = "Completed"},
            new Ref_Transaction_Status{ Transaction_Status_Code = "TSC03", Transaction_Status_Description = "Disputed"},
            new Ref_Transaction_Status{ Transaction_Status_Code = "TSC04", Transaction_Status_Description = "Challenged"}
        };

        public static List<Financial_Transactions> Financial_Transactions = new List<Financial_Transactions>
        {
            new Financial_Transactions
            {
                Transaction_Id = 25130,
                Account_Id = 1011,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25131,
                Account_Id = 1012,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25132,
                Account_Id = 1021,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25133,
                Account_Id = 1022,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25134,
                Account_Id = 1031,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25135,
                Account_Id = 1032,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25136,
                Account_Id = 1041,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25137,
                Account_Id = 1042,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25138,
                Account_Id = 1051,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25139,
                Account_Id = 1052,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25140,
                Account_Id = 9911,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25141,
                Account_Id = 9912,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25142,
                Account_Id = 9921,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            },
            new Financial_Transactions
            {
                Transaction_Id = 25143,
                Account_Id = 9922,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC01",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = new DateTime(2022,11,07),
                Amount_of_Transaction = 1000
            }
        };
    }
}
