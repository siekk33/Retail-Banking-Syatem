using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repositories;

namespace TransactionMicroservice.Services
{
    public class TransactionService : ITransactionService
    {
        private IHttpClientFactory _httpClientFactory;
        private ITransactionRepository transactionRepository;

        public TransactionService(IHttpClientFactory httpClientFactory, ITransactionRepository _transactionRepository)
        {
            _httpClientFactory = httpClientFactory;
            transactionRepository = _transactionRepository;
        }

        public async Task<TransactionStatus> Deposit(int accountId, double amount)
        {
            TransactionStatus status1 = new TransactionStatus
            {
                Message = "Failed!",
                Source_Balance = 0
            };

            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:7001/api/transaction");

            HttpResponseMessage response1 = httpClient.GetAsync("https://localhost:6001/api/Accounts/GetAccountById?accountid=" + accountId).Result;//url for account microservice
            if (response1.IsSuccessStatusCode)
            {
                Account account = await response1.Content.ReadAsAsync<Account>();
                if (account != null)
                {
                    status1.Source_Balance = account.Balance_Amount;

                    var message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:6001/api/Accounts/DepositAmount?accountId=" + accountId + "&amount=" + amount);//url for account microservice
                    var response = await httpClient.SendAsync(message);
                    if (response.IsSuccessStatusCode)
                    {
                        status1 = await response.Content.ReadAsAsync<TransactionStatus>();

                        transactionRepository.Deposit(accountId, amount);
                        return status1;
                    }
                    else
                    {
                        return status1;
                    }
                }
                else
                {
                    status1.Message = "Check if your account exists";
                    return status1;
                }
            }
            else
            {
                status1.Message = "Check if your account exists";
                return status1;
            }
        }

        public async Task<TransactionStatus> Withdraw(int accountId, double amount)
        {
            TransactionStatus status1 = new TransactionStatus
            {
                Message = "Failed!",
                Source_Balance = 0
            };

            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:7001/api/transaction");
            HttpResponseMessage response1 = httpClient.GetAsync("https://localhost:6001/api/Accounts/GetAccountById?accountid=" + accountId).Result;//url for acc service//url for account microservice
            if (response1.IsSuccessStatusCode)
            {
                Account account = await response1.Content.ReadAsAsync<Account>();
                if (account != null)
                {
                    status1.AccountId = account.AccountId;
                    status1.Source_Balance = account.Balance_Amount;
                    if (account.Balance_Amount > amount)
                    {
                        HttpResponseMessage response2 = httpClient.GetAsync("https://localhost:8001/api/Rule/EvaluateMinBalance?balance=" + account.Balance_Amount + "&AccountId=" + accountId).Result;//url for rules microservice

                        if (response2.IsSuccessStatusCode)
                        {
                            string transactionStatus = await response2.Content.ReadAsStringAsync();
                            if (transactionStatus.Equals("Allowed"))
                            {
                                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:6001/api/Accounts/WithdrawAmount?accountid=" + accountId + "&amount=" + amount);//url for account microservice
                                var response3 = await httpClient.SendAsync(message);

                                if (response3.IsSuccessStatusCode)
                                {
                                    status1 = await response3.Content.ReadAsAsync<TransactionStatus>();
                                    transactionRepository.Withdraw(accountId, amount);
                                    return status1;
                                }
                                else
                                {
                                    status1.Message = "Some error occurred.Withdrawal failed!";
                                    return status1;
                                }
                            }
                            else
                            {
                                status1.Message = "You are not allowed to perform transaction. Minimum balance criteria should be followed.";
                                return status1;
                            }
                        }
                        else
                        {
                            status1.Message = "Error in Connection with Rules Service.";
                            return status1;
                        }
                    }
                    else
                    {
                        status1.Message = "You do not suffiecient balance to withdraw amount!";
                        return status1;
                    }
                }
                else
                {
                    status1.Message = "Check if your account exists";
                    return status1;
                }
            }
            else
            {
                status1.Message = "Check if your account exists";
                return status1;
            }
        }

        public async Task<IEnumerable<TransactionStatus>> Transfer(int sourceAccountId, int targetAccountId, double amount)
        {
            List<TransactionStatus> statuses = new List<TransactionStatus>();
            TransactionStatus withdrawStatus = await Withdraw(sourceAccountId, amount);
            statuses.Add(withdrawStatus);

            //"Transaction Details : Rs." + amount + " withdrawn from AccountID : " + ts.AccountId;
            if (withdrawStatus.Message.Equals("Transaction Details : Rs." + amount + " withdrawn from AccountID : " + sourceAccountId))
            {
                TransactionStatus depositStatus = await Deposit(targetAccountId, amount);
                statuses.Add(depositStatus);
                // "Transaction Details : Rs." + amount + " deposited into AccountID : " + ts.AccountId;
                if (depositStatus.Message.Equals("Transaction Details : Rs." + amount + " deposited into AccountID : " + targetAccountId))
                {
                    return statuses;
                }
                else
                {
                    TransactionStatus depositInSource = await Deposit(sourceAccountId, amount);
                    statuses.Remove(withdrawStatus);
                    return statuses;
                }
            }
            else
            {
                return statuses;
            }
        }

        public async Task<IEnumerable<Financial_Transactions>> GetTransactions(int customerId)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:7001/api/transaction");
            HttpResponseMessage response1 = httpClient.GetAsync("https://localhost:6001/api/Accounts/GetCustomerAccountDetailsById?customerId=" + customerId).Result;//url for account microservice
            List<Financial_Transactions> transactions = new List<Financial_Transactions>();
            if (response1.IsSuccessStatusCode)
            {
                IEnumerable<Account> accounts = await response1.Content.ReadAsAsync<IEnumerable<Account>>();
                if (accounts.Count() > 0)
                {
                    foreach (Account a in accounts)
                    {
                        IEnumerable<Financial_Transactions> fList = transactionRepository.GetTransactions(a.AccountId);
                        if (fList.Count() > 0)
                        {
                            foreach (Financial_Transactions f in fList)
                            {
                                transactions.Add(f);
                            }
                        }
                    }
                    return transactions;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
