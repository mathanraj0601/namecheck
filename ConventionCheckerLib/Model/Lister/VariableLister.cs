using CLI.Engine.Lister;
using CLI.Engine;
using CLI.Model.TemplateRules;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace CLI.Model.Lister
{
    public class VariableLister
    {
        public List<string> Names { get; set; }
        public VariableLister()
        {
            Names = new List<string>();
        }

        public static void ListNames(VariableDeclaratorSyntax node,
                            TemplateLister followingList,
                            TemplateLister violatingList,
                            NamingConventionEngine namingConventionEngine,
                            TemplateRule templateRules)
        {
          
                NameListerEngine.Get(followingList.VariableLister.Names,
                                      violatingList.VariableLister.Names,
                                      namingConventionEngine,
                                      templateRules.VariableRule.Convention,
                                      node.Identifier.Text);
                return;


        }
    }

}
