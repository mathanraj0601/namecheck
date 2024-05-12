using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class ConstantRule
    {
        public string Convention { get; set; }
        public ConstantRule()
        {
            Convention = "UPPERCASE";
        }

        public ConstantRule(string convention)
        {
            Convention = convention;
        }
    }
}
