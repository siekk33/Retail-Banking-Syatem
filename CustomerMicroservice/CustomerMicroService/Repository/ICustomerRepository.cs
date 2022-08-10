using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.Repository
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerDetails(int customerId);
        public CustomerCreationStatus CreateCustomer(Customer customer);

    }
}
