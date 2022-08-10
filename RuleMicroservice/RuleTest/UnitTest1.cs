using NUnit.Framework;
using RuleMicroservice.Repository;
using RuleMicroservice.Service;
using RuleMicroservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace RulesTest
{
    [TestFixture]
    public class Tests
    {
        private Mock<IRulesServices> mockService = new Mock<IRulesServices>();
        private RuleController controller;
        private RuleRepository rules = new RuleRepository();

        [Test]
        public void MicroserviceTestCase()
        {
            int accountid = 101;
            double balance = 400;
            string a = "Denied";
            mockService.Setup(e => e.Check(balance, accountid)).Returns(a);
            controller = new RuleController(mockService.Object);
            var result = controller.EvaluateMinBal(balance, accountid);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public void NegativeTestCaseOutput()
        {
            int accountid = 102;
            double balance = 500;
            string a = "Denied";
            string answer = rules.EvaluateMinBal(balance, accountid);
            Assert.AreEqual(answer, a);
        }
        [Test]
        public void PositiveTestCaseOutput()
        {
            int accountid = 103;
            double balance = 1000;
            string a = "Allowed";
            string answer = rules.EvaluateMinBal(balance, accountid);
            Assert.AreEqual(answer, a);
        }
    }
}