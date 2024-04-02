using CLI.Model.TemplateRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.Lister
{
    public class TemplateLister
    {
        public string TenplateRuleName { get; set; }
        public NameSpaceLister NameSpaceLister { get; set; }
        public ClassLister ClassLister { get; set; }
        public InterfaceLister InterfaceLister { get; set; }
        public MethodLister MethodLister { get; set; }
        public PropertyLister PropertyLister { get; set; }
        public FieldLister FieldLister { get; set; }
        public StructLister StructLister { get; set; }
        public EnumLister EnumLister { get; set; }
        public ConstantLister ConstantLister { get; set; }
        public RecordLister RecordLister { get; set; }
        public DelegateLister DelegateLister { get; set; }
        public VariableLister VariableLister { get; set; }

        public TemplateLister(string ruleName)
        {
            TenplateRuleName = ruleName;
            NameSpaceLister = new NameSpaceLister();
            ClassLister = new ClassLister();
            InterfaceLister = new InterfaceLister();
            MethodLister = new MethodLister();
            PropertyLister = new PropertyLister();
            FieldLister = new FieldLister();
            StructLister = new StructLister();
            EnumLister = new EnumLister();
            ConstantLister = new ConstantLister();
            RecordLister = new RecordLister();
            DelegateLister = new DelegateLister();
            VariableLister = new VariableLister();
        }


    }
}
