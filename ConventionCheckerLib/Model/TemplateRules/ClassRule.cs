using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class ClassRule
    {
        public string PrivateConvention { get; set; }
        public string PublicConvention { get; set; }
        public string InternalConvention { get; set; }
        public string ProtectedConvention { get; set; }

        public ClassRule()
        {
            PublicConvention = "PASCALCASE";
            PrivateConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";  
            ProtectedConvention = "PASCALCASE";
        }
        public ClassRule(string privateConvention, string publicConvention, string internalConvention,string protectedConvention)
        {
            PrivateConvention = privateConvention;
            PublicConvention = publicConvention;
            InternalConvention = internalConvention;
            ProtectedConvention = protectedConvention;
        }
    }
}
