using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.TemplateRules
{
    public class TemplateRule
    {
        public string RuleName { get; set; }
        public NameSpaceRule NameSpaceRule { get; set; }
        public ClassRule ClassRule { get; set; }
        public InterfaceRule InterfaceRule { get; set; }
        public MethodRule MethodRule { get; set; }
        public PropertyRule PropertyRule { get; set; }
        public FieldRule FieldRule { get; set; }
        public StructRule StructRule { get; set; }
        public EnumRule EnumRule { get; set; }
        public ConstantRule ConstantRule { get; set; }
        public RecordRule RecordRule { get; set; }
        public DelegateRule DelegateRule { get; set; }
        public VariableRule VariableRule { get; set; }
        public TemplateRule(string ruleName)
        {
            RuleName = ruleName;
            NameSpaceRule = new NameSpaceRule();
            ClassRule = new ClassRule();
            InterfaceRule = new InterfaceRule();
            MethodRule = new MethodRule();
            PropertyRule = new PropertyRule();
            FieldRule = new FieldRule();
            StructRule = new StructRule();
            EnumRule = new EnumRule();
            ConstantRule = new ConstantRule();
            RecordRule = new RecordRule();
            DelegateRule = new DelegateRule();
            VariableRule = new VariableRule();
        }

    }
}
