using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class StructRule
    {
        public string PublicConvention { get; set; }
        public string InternalConvention { get; set; }

        public StructRule()
        {
            PublicConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";
        }
        public StructRule(string publicConvention, string internalConvention)
        {
            PublicConvention = publicConvention;
            InternalConvention = internalConvention;
        }
    }
}
