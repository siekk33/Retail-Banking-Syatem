using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;
using TransactionMicroservice.Data;
using System.Net.Http;
using TransactionMicroservice.Services;
using Microsoft.AspNetCore.Authorization;

namespace TransactionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //https://localhost:44376/api/transaction

        private ITransactionService service;

        public TransactionController(ITransactionService _service)
        {
            service = _service;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(int accountId, double amount)
        {
            if (accountId <= 0 || amount <= 0)
            {
                log.Info("Invalid AccountId or Amount Details Please Check");
                return BadRequest("Invalid AccountId or Amount Details Please Check");
            }
            else
            {
                TransactionStatus status = await service.Deposit(accountId, amount);
                if (status != null)
                {
                    log.Info("successfully Deposited the Amount");
                    return Ok(status);
                }
                else
                {
                    log.Info("NoContent Found");
                    return NoContent();
                }

            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(int accountId, double amount)
        {
            if (accountId <= 0 || amount <= 0)
            {
                log.Info("Invalid AccountId or Amount Details Please Check");
                return BadRequest("Invalid AccountId or Amount Details Please Check");
            }
            else
            {
                TransactionStatus status = await service.Withdraw(accountId, amount);
                if (status != null)
                {
                    log.Info("Status Details");
                    return Ok(status);
                }
                else
                {
                    log.Info("No Content Found");
                    return NoContent();
                }

            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(int sourceAccountId, int targetAccountId, double amount)
        {
            if (sourceAccountId <= 0 || targetAccountId <= 0 || amount <= 0)
            {
                log.Info("Invalid AccountId or Amount Details Please Check");
                return BadRequest("Invalid AccountId or Amount Details Please Check");
            }
            else
            {
                IEnumerable<TransactionStatus> status = await service.Transfer(sourceAccountId, targetAccountId, amount);
                if (status != null)
                {
                    log.Info("Status Details");
                    return Ok(status);
                }
                else
                {
                    log.Info("No Content Found");
                    return NoContent();
                }

            }
        }


        [HttpGet("getTransactions")]
        public async Task<IActionResult> GetTransactions(int customerId)
        {
            if (customerId <= 0)
            {
                log.Info("Invalid CustomerId Please Check");
                return BadRequest("Invalid CustomerId  Please Check");
            }
            else
            {
                IEnumerable<Financial_Transactions> financial_Transactions = await service.GetTransactions(customerId);
                if (financial_Transactions == null)
                {
                    log.Info("No Content Found");
                    return NoContent();
                }
                else if (financial_Transactions.Count() > 0)
                {
                    log.Info("FinancialTransaction Details");
                    return Ok(financial_Transactions);
                }
                else
                {
                    log.Info("No transactions found for your accounts");
                    return Content("No transactions found for your accounts");

                }
            }
        }

    }
}
