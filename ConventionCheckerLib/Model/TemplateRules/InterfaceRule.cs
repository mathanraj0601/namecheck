using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class InterfaceRule
    {
        public string PublicConvention { get; set; }
        public string InternalConvention { get; set; }

        public InterfaceRule()
        {
            PublicConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";
        }
        public InterfaceRule(string publicConvention,string internalConvention)
        {
            PublicConvention = publicConvention;
            InternalConvention = internalConvention;
        }
    }
}
