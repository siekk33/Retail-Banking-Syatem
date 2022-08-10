using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuleMicroservice.Models;

namespace RuleMicroservice.Service
{
    public interface IRulesServices
    {
        public string Check(double bal, int accountid);
        public IEnumerable<Rule> GetAllIds();
    }
}
