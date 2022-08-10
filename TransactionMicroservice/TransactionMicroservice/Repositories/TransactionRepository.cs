using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;
using TransactionMicroservice.Data;

namespace TransactionMicroservice.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        List<Financial_Transactions> financial_Transactions1 = DBHelper.Financial_Transactions;
        public void Deposit(int accountId, double amount)
        {
            int maxId = financial_Transactions1.Max(i => i.Transaction_Id);
            financial_Transactions1.Add(new Financial_Transactions
            {
                Transaction_Id = maxId + 1,
                Account_Id = accountId,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC02",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = DateTime.Now,
                Amount_of_Transaction = amount
            });
        }

        public void Withdraw(int accountId, double amount)
        {
            int maxId = financial_Transactions1.Max(i => i.Transaction_Id);
            financial_Transactions1.Add(new Financial_Transactions
            {
                Transaction_Id = maxId + 1,
                Account_Id = accountId,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC02",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = DateTime.Now,
                Amount_of_Transaction = amount
            });
        }

        public void Transfer(int sourceAccountId, int targetAccountId, double amount)
        {
            int maxId = financial_Transactions1.Max(i => i.Transaction_Id);
            financial_Transactions1.Add(new Financial_Transactions
            {
                Transaction_Id = maxId + 1,
                Account_Id = sourceAccountId,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC02",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = DateTime.Now,
                Amount_of_Transaction = amount
            });

            financial_Transactions1.Add(new Financial_Transactions
            {
                Transaction_Id = maxId + 2,
                Account_Id = targetAccountId,
                Counterparty_Id = 1,
                Payment_Method_Code = "PMCode1",
                Service_Id = 1,
                Transaction_Status_Code = "TSC02",
                Transaction_Type_Code = "T01",
                Date_of_Transaction = DateTime.Now,
                Amount_of_Transaction = amount
            });
        }

        public IEnumerable<Financial_Transactions> GetTransactions(int accountId)
        {
            List<Financial_Transactions> financial_Transactions = new List<Financial_Transactions>();
            foreach (Financial_Transactions f in DBHelper.Financial_Transactions)
            {
                if (f.Account_Id == accountId)
                {
                    financial_Transactions.Add(f);
                }
            }
            if (financial_Transactions.Count > 0)
            {
                return financial_Transactions;
            }
            else
            {
                return null;
            }
        }
    }
}
