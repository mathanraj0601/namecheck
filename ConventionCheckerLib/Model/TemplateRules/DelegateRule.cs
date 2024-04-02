using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class DelegateRule
    {
        public string PublicConvention { get; set; }
        public string InternalConvention { get; set; }

        public DelegateRule()
        {
            PublicConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";
        }
        public DelegateRule(string publicConvention, string internalConvention)
        {
            PublicConvention = publicConvention;
            InternalConvention = internalConvention;
        }
    }
}
