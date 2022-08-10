using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuleMicroservice.Repository;
using log4net;
using RuleMicroservice.Models;

namespace RuleMicroservice.Service
{
    public class RulesService : IRulesServices
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IRuleRepository rules;
        public RulesService(IRuleRepository ruleRepository)
        {
            rules = ruleRepository;
        }
        public string Check(double bal, int accountid)
        {
            log.Debug("Entered Services");
            return rules.EvaluateMinBal(bal, accountid);
        }
        public IEnumerable<Rule> GetAllIds()
        {
            return rules.GetAllIds();
        }
    }
}
