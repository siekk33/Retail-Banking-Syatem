using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using RuleMicroservice.Models;
using RuleMicroservice.Database;

namespace RuleMicroservice.Repository
{
    public class RuleRepository : IRuleRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string EvaluateMinBal(double balance, int AccountId)
        {
            Rule rule = new Rule();
            rule.balance = balance;
            rule.AccountId = AccountId;

            List<Rule> RuleLists = RulesDB.RuleList;

            string ruleStatus = "Denied";
            double minBalance = 800;
            log.Debug("Checking Available Balance in above account id" + rule.AccountId);
            if (rule.balance < minBalance)
            {
                ruleStatus = "Denied";
                log.Error("You dont have the mininum balance for the transaction" + rule.balance);
                log.Info("Account" + rule.AccountId + "is denied");

            }
            else if (rule.balance > minBalance)
            {
                ruleStatus = "Allowed";
                log.Debug("You have the adequate balance for transcation" + balance);
                log.Info("You are account" + AccountId + "allowed for transcation");
            }
            RuleLists.Add(rule);
            return ruleStatus;
        }
        public IEnumerable<Rule> GetAllIds()
        {
            return RulesDB.RuleList;
        }
    }
}
