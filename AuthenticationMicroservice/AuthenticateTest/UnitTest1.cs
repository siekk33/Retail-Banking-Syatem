using Authentication;
using Authentication.Controllers;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;

namespace AuthenticationTest
{
    public class Tests
    {
        public class AuthenticationTesting
        {
            private UsersController _usersController;
            private Mock<IUserService> _mockService;
            [SetUp]
            public void Setup()
            {
                _mockService = new Mock<IUserService>();
                _usersController = new UsersController(_mockService.Object);
            }

            [Test]
            public void AuthenticateSuccessTest()
            {
                var username = "hirito";
                var password = "aincrad";
                var user = new User { Id = 992, FirstName = "Hariharan", LastName = "V", Username = "hirito", Password = "aincrad", Role = Role.Admin };
                AuthenticateModel model = new AuthenticateModel() { Username = username, Password = password };
                _mockService.Setup(x => x.Authenticate(username, password)).Returns(user);
                var result = _usersController.Authenticate(model);
                var okResult = (IStatusCodeActionResult)result;
                Assert.AreEqual(200, okResult.StatusCode);
            }

            [Test]
            public void AuthenticateFailTest()
            {
                var username = "asd";
                var password = "fasd";
                var user = new User { };
                AuthenticateModel model = new AuthenticateModel() { Username = username, Password = password };
                _mockService.Setup(x => x.Authenticate(username, password)).Returns((User)null);
                var result = _usersController.Authenticate(model);
                var badResult = (IStatusCodeActionResult)result;
                Assert.AreEqual(400, badResult.StatusCode);
            }

            [Test]
            public void CreateUserTest()
            {
                var user = new User { Id = 106, FirstName = "Asuna", LastName = "Yukki", Username = "lightning", Password = "queen" };
                var userCreationStatus = new UserCreationStatus { Id = 106, Message = "User Created Successfully" };
                _mockService.Setup(x => x.CreateUser(user)).Returns(userCreationStatus);
                var result = _usersController.CreateUser(user);
                var okresult = (IStatusCodeActionResult)result;
                Assert.AreEqual(200, okresult.StatusCode);
            }

            [Test]
            public void CreateUserFailTest()
            {
                var user = new User { Id = 106, FirstName = "", LastName = "", Username = "lightning", Password = "" };
                var userCreationStatus = new UserCreationStatus { Id = 106, Message = "User Created Successfully" };
                _mockService.Setup(x => x.CreateUser(user)).Returns((UserCreationStatus)null);
                var result = _usersController.CreateUser(user);
                var badresult = (IStatusCodeActionResult)result;
                Assert.AreEqual(400, badresult.StatusCode);
            }
        }
    }
}