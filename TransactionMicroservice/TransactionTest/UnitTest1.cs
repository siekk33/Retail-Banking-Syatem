using NUnit.Framework;
using TransactionMicroservice.Controllers;
using Moq;
using TransactionMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using TransactionMicroservice.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace TransactionTestProject
{
    public class Tests
    {
        TransactionController controller;
        Mock<ITransactionService> mockservice;
        [SetUp]
        public void Setup()
        {
            mockservice = new Mock<ITransactionService>();
            controller = new TransactionController(mockservice.Object);
        }

        [Test]
        public async Task DepositBadrequest()
        {
            var accountId = 0;
            var amount = 0;
            var result = await controller.Deposit(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }
        [Test]
        public async Task DepositreturnsNoContent()
        {
            var accountId = 1001;
            var amount = 9000;
            TransactionStatus transaction = null;
            mockservice.Setup(s => s.Deposit(accountId, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Deposit(accountId, amount);

        }
        [Test]
        public async Task WithdrawlBadrequest()
        {
            var accountId = 0;
            var amount = 0;
            var result = await controller.Withdraw(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task WithdrawlNoContent()
        {
            var accountId = 1010;
            var amount = 9000;
            TransactionStatus transaction = null;
            mockservice.Setup(s => s.Withdraw(accountId, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Withdraw(accountId, amount);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task TransferBadRequest()
        {
            var sourceaccountId = 0;
            var destinationaccountid = 0;
            var amount = 0;
            var result = await controller.Transfer(sourceaccountId, destinationaccountid, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task TransferNoContent()
        {
            var sourceaccountId = 1010;
            var destinationaccountid = 1005;
            var amount = 9000;
            IEnumerable<TransactionStatus> transaction = null;
            mockservice.Setup(s => s.Transfer(sourceaccountId, destinationaccountid, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Transfer(sourceaccountId, destinationaccountid, amount);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task GetTransactionsBadRequest()
        {
            var customerid = 0;
            var result = await controller.GetTransactions(customerid);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task GetTransactionNoContent()
        {
            var customerid = 1001;
            IEnumerable<Financial_Transactions> transaction = null;
            mockservice.Setup(s => s.GetTransactions(customerid)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.GetTransactions(customerid);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DepositOkResult()
        {
            var accountId = 1001;
            var amount = 1000;
            TransactionStatus transaction = new TransactionStatus() { Message = "completed", Source_Balance = 2000 };
            mockservice.Setup(s => s.Deposit(accountId, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Deposit(accountId, amount);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public async Task WithdrawlOkResult()
        {
            var accountId = 102;
            var amount = 3000;
            TransactionStatus transaction = new TransactionStatus() { Message = "completed", Source_Balance = 2000 };
            mockservice.Setup(s => s.Withdraw(accountId, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Withdraw(accountId, amount);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public async Task TransferOkResult()
        {
            var sourceaccountId = 102;
            var destinationaccountid = 103;
            var amount = 9000;
            List<TransactionStatus> transaction;
            transaction = new List<TransactionStatus>() { new TransactionStatus { Message = "completed", Source_Balance = 2000 } };
            mockservice.Setup(s => s.Transfer(sourceaccountId, destinationaccountid, amount)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.Transfer(sourceaccountId, destinationaccountid, amount);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public async Task GetTransactionOkResult()
        {
            var customerid = 1001;
            List<Financial_Transactions> transaction;
            transaction = new List<Financial_Transactions>() {
                new Financial_Transactions
                {
                    Transaction_Id = 5,
                    Account_Id = 1001,
                    Counterparty_Id = 1,
                    Payment_Method_Code = "PMCode1",
                    Service_Id = 1,
                    Transaction_Status_Code = "TSC02",
                    Transaction_Type_Code = "T01",
                    Date_of_Transaction = DateTime.Now,
                    Amount_of_Transaction = 1000
                }
            };
            mockservice.Setup(s => s.GetTransactions(customerid)).ReturnsAsync(transaction);
            TransactionController control = new TransactionController(mockservice.Object);
            var result = await control.GetTransactions(customerid);

            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }
    }
}