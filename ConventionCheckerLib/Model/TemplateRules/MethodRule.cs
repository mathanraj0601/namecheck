using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class MethodRule
    {
        public string PublicConvention { get; set; }
        public string PrivateConvention { get; set; }
        public string InternalConvention { get; set; }
        public string ProtectedConvention { get; set; }


        public MethodRule()
        {
                PublicConvention = "PASCALCASE";
                PrivateConvention = "PASCALCASE";
                InternalConvention = "PASCALCASE";
                ProtectedConvention = "PASCALCASE";
        }

        public MethodRule(string publicConvention, string privateConvention, string internalConvention,string protectedConvention)
        {
            PublicConvention = publicConvention;
            PrivateConvention = privateConvention;
            InternalConvention = internalConvention;
            ProtectedConvention = protectedConvention;
        }
    }
}
