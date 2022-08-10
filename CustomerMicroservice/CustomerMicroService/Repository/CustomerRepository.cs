using customer.data;
using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CustomerCreationStatus CreateCustomer(Customer Customer)
        {
            try
            {
                log.Info("Customer creation is performing");


                CustomerCreationStatus Result = new CustomerCreationStatus();
                var customerNotAdminList = CustomerDbHelper.customers.Where(a => a.CustomerId < 990);
                Customer.CustomerId = (customerNotAdminList.Max(a => a.CustomerId)) + 1;
                CustomerDbHelper.customers.Add(Customer);
                Result.CustomerId = Customer.CustomerId;
                Result.Status = "Success";
                return Result;


            }
            catch (Exception e)
            {
                log.Error("Creation of customer could n't be happen due to error contacting the account microservice ");
                log.Debug(e);
                return null;

            }
        }

        public Customer GetCustomerDetails(int CustomerId)
        {
            try
            {
                log.Info(" Getting Customer details is performing");

                Customer Result = CustomerDbHelper.customers.Find(x => x.CustomerId == CustomerId);
                return Result;
            }
            catch (Exception e)
            {
                log.Info(" Getting Customer details is  not performed");
                log.Debug(e);
                throw new NullReferenceException();

            }
        }
    }
}
