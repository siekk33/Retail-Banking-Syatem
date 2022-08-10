using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using RuleMicroservice.Service;
using RuleMicroservice.Models;

namespace RuleMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuleController : ControllerBase
    {
        private readonly IRulesServices RulesServices;
        public RuleController(IRulesServices services)
        {
            RulesServices = services;
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet("EvaluateMinBalance")]
        public IActionResult EvaluateMinBal(double balance, int AccountId)
        {
            log.Debug("Entered Controller");
            string result = RulesServices.Check(balance, AccountId);
            return Ok(result);
        }
        [HttpGet("GetAllIDS")]
        public IActionResult GetIDS()
        {
            IEnumerable<Rule> result = RulesServices.GetAllIds();
            return Ok(result);
        }

    }

}
