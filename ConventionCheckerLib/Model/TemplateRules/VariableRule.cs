using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class VariableRule
    {
        public string Convention { get; set; }
        public VariableRule()
        {
            Convention = "PASCALCASE";
        }
        public VariableRule(string convention)
        {
            Convention = convention;
        }
    }

    
}
