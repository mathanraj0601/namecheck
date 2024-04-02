using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class NameSpaceRule
    {
        public string Convention { get; set; }
        public NameSpaceRule()
        {
            Convention = "PASCALCASE";
        }
        public NameSpaceRule(string convention)
        {
            Convention = convention;
        }
    }
}
