using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repositories
{
    public interface ITransactionRepository
    {
        public void Deposit(int accountId, double amount);

        public void Withdraw(int accountId, double amount);

        public void Transfer(int sourceAccountId, int targetAccountId, double amount);

        public IEnumerable<Financial_Transactions> GetTransactions(int accountId);
    }
}
