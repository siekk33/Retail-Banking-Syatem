using NUnit.Framework;
using customer.Controllers;
using customer.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using customer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;
using System;
using CustomerMicroservice.Models;

namespace customerTesting
{
    public class Tests
    {
        [TestFixture]
        public class CustomerTesting
        {
            private CustomersController controller;
            private Mock<ICustomerService> mockservice;

            [SetUp]
            public void Setup()
            {
                mockservice = new Mock<ICustomerService>();
                controller = new CustomersController(mockservice.Object);
            }

            [Test]
            public void GetCustomerDetailInvalidInpuReturnsBadRequest()
            {
                var id = 0;
                IActionResult result = controller.GetCustomerDetails(id);
                Assert.IsInstanceOf<BadRequestObjectResult>(result);
            }

            [Test]
            public void GetCustomerDetailValidInputReturnsBadRequest()
            {
                var id = 100;
                IActionResult result = controller.GetCustomerDetails(id);
                Assert.IsInstanceOf<BadRequestObjectResult>(result);
            }

            [Test]
            public void GetCustomerDetailValidInputReturnsOkResult()
            {
                var id = 103;
                Customer customer = new Customer() { CustomerId = id, FirstName = "Siva", LastName = "Karthikeyan", Address = "Chennai", DateOfBirth = new DateTime(1998, 04, 15), PanNumber = "ABCD10003C" };
                mockservice.Setup(x => x.GetCustomerDetails(id)).Returns(customer);
                var result = controller.GetCustomerDetails(id);
                var okResult = (IStatusCodeActionResult)result;
                Assert.AreEqual(200, okResult.StatusCode);
            }

            [Test]
            public async Task CreateCustomerInvalidModelReturnsBadRequest()
            {
                Customer customer = new Customer() { FirstName = " ", LastName = "Kohli", Address = "Delhi", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B" };
                controller.ModelState.AddModelError("FirstName", "Required");
                var result = await controller.CreateCustomer(customer);
                Assert.IsInstanceOf<BadRequestObjectResult>(result);
            }

            [Test]
            public async Task CreateCustomerValidModelReturnsNoContent()
            {
                Customer customer = new Customer() { CustomerId = 1, FirstName = "Mike", LastName = "Hussey", Address = "Perth", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B" };
                CustomerCreationStatus status = null;
                mockservice.Setup(x => x.CreateCustomer(customer)).ReturnsAsync(status);
                var result = await controller.CreateCustomer(customer);
                Assert.IsInstanceOf<NoContentResult>(result);
            }

            [Test]
            public async Task CreateCustomerValidModelReturnsOkResult()
            {
                Customer customer = new Customer() { CustomerId = 106, FirstName = "sai", LastName = "Kumaravelu", Address = "Chennai", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B" };
                CustomerCreationStatus status = new CustomerCreationStatus() { CustomerId = 1004, Status = "Success" };
                mockservice.Setup(x => x.CreateCustomer(customer)).ReturnsAsync(status);
                var result = await controller.CreateCustomer(customer);
                var okResult = (IStatusCodeActionResult)result;
                Assert.AreEqual(200, okResult.StatusCode);
            }

        }
    }
}