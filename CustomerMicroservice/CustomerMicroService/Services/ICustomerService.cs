using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.Services
{
    public interface ICustomerService
    {
        public Customer GetCustomerDetails(int customerId);

        public Task<CustomerCreationStatus> CreateCustomer(Customer customer);

    }
}
