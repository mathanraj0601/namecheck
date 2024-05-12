using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class PropertyRule
    {
        public string PublicConvention { get; set; }
        public string PrivateConvention { get; set; }
        public string InternalConvention { get; set; }
        public string ProtectedConvention { get; set; }
        public PropertyRule()
        {
            PublicConvention = "PASCALCASE";
            PrivateConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";
            ProtectedConvention = "PASCALCASE";
        }
        public PropertyRule(string publicConvention, string privateConvention, string internalConvention, string protectedConvention)
        {
            PublicConvention = publicConvention;
            PrivateConvention = privateConvention;
            InternalConvention = internalConvention;
            ProtectedConvention = protectedConvention;
        }


    }
}
