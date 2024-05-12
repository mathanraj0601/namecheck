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
    public class NameSpaceLister
    {
        public List<string> Names { get; set; }

        public NameSpaceLister() { 
            Names = new List<string>();
        }
        public static void ListNames(NamespaceDeclarationSyntax node,
                          TemplateLister followingList,
                          TemplateLister violatingList,
                          NamingConventionEngine namingConventionEngine,
                          TemplateRule templateRules)
        {

            NameListerEngine.Get(followingList.NameSpaceLister.Names,
                                  violatingList.NameSpaceLister.Names,
                                  namingConventionEngine,
                                  templateRules.NameSpaceRule.Convention,
                                  node.Name.ToString());
            return;


        }
    }
}
