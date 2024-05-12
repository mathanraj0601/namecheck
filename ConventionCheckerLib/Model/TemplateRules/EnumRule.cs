using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class EnumRule
    {
        public string Convention { get; set; }

        public EnumRule()
        {
            Convention = "PASCALCASE";
        }
        public EnumRule(string convention)
        {
            Convention =  convention;
        }
    }
}
