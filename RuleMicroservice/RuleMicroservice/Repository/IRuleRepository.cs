using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuleMicroservice.Models;

namespace RuleMicroservice.Repository
{
    public interface IRuleRepository
    {
        public string EvaluateMinBal(double balance, int AccountId);
        public IEnumerable<Rule> GetAllIds();
    }
}
