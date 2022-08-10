using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace RuleMicroservice
{
    public class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}
