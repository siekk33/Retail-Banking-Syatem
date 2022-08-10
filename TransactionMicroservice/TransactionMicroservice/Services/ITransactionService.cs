using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Services
{
    public interface ITransactionService
    {
        public Task<TransactionStatus> Deposit(int accountId, double amount);

        public Task<TransactionStatus> Withdraw(int accountId, double amount);

        public Task<IEnumerable<TransactionStatus>> Transfer(int sourceAccountId, int targetAccountId, double amount);

        public Task<IEnumerable<Financial_Transactions>> GetTransactions(int customerId);
    }
}
