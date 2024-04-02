using CLI.Engine.Lister;
using CLI.Engine;
using CLI.Model.TemplateRules;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Model.Lister
{
    public class ConstantLister
    {
        public List<string> Names { get; set; }
        public ConstantLister()
        {
            Names = new List<string>();
        }

        public static void ListNames(VariableDeclaratorSyntax node,
                        TemplateLister followingList,
                        TemplateLister violatingList,
                        NamingConventionEngine namingConventionEngine,
                        TemplateRule templateRules)
        {

            NameListerEngine.Get(followingList.ConstantLister.Names,
                                  violatingList.ConstantLister.Names,
                                  namingConventionEngine,
                                  templateRules.ConstantRule.Convention,
                                  node.Identifier.Text);
            return;


        }

      
    }
}
