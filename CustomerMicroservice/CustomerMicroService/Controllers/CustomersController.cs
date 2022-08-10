using customer.data;
using customer.Repository;
using customer.Services;
using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICustomerService repository;//create a object for customerservice
        public CustomersController(ICustomerService Irepository)//inject with controller class when loading the controller class
        {
            repository = Irepository;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()//getting  details of all the customers
        {
            return CustomerDbHelper.customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("GetCustomerDetails")]
        public IActionResult GetCustomerDetails(int CustomerId)//get the particular details of a customer by the ID 
        {
            if (CustomerId <= 0)
            {
                return BadRequest("Customer ID must be greater than zero");
            }
            else
            {

                Customer Customer = repository.GetCustomerDetails(CustomerId);
                if (Customer != null)
                {
                    log.Debug(" Getting Customer details is   performed.");
                    return Ok(Customer);
                }
                else
                {
                    log.Error(" Getting Customer details is  not performed");
                    return BadRequest("Customer details not found");
                }


            }
        }

        // POST api/<CustomersController>
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer value)//creating a new customer
        {

            if (ModelState.IsValid)
            {
                CustomerCreationStatus Status = await repository.CreateCustomer(value);
                if (Status != null)
                {
                    log.Debug(" Creating Customer details is   performed.");
                    return Ok(Status);
                }
                else
                {
                    log.Debug(" Creating Customer details is not performed due to error from response in account microservice.");
                    return NoContent();
                }
            }
            else
            {
                log.Debug(" Creating Customer details is not performed due to Invalid Information.");
                return BadRequest("Customer Details are Invalid");
            }
        }


    }
}
