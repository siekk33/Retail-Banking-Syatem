using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuleMicroservice.Models;

namespace RuleMicroservice.Database
{
    public class RulesDB
    {
        public static List<Rule> RuleList = new List<Rule>()
        {
            new Rule(){AccountId=101,balance=10000}
        };
    }
}
