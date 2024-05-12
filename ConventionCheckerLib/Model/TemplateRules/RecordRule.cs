using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class RecordRule
    {
        public string PublicConvention { get; set; }
        public string InternalConvention { get; set; }

        public RecordRule()
        {
            PublicConvention = "PASCALCASE";
            InternalConvention = "PASCALCASE";
        }
        public RecordRule(string publicConvention, string internalConvention)
        {
            PublicConvention = publicConvention;
            InternalConvention = internalConvention;
        }
    }
}
