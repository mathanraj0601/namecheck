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
    public class DelegateLister
    {
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }

        public DelegateLister()
        {
            PublicNames = new List<string>();
            InternalNames = new List<string>();
        }

        public static void ListNames(DelegateDeclarationSyntax node,
                        TemplateLister followingList,
                        TemplateLister violatingList,
                        NamingConventionEngine namingConventionEngine,
                        TemplateRule templateRules)
        {


            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.InterfaceLister.PublicNames,
                                     violatingList.InterfaceLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.InterfaceRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.InterfaceLister.InternalNames,
                                     violatingList.InterfaceLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.InterfaceRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }



            if (!node.Modifiers.Any())
            {
                NameListerEngine.Get(followingList.InterfaceLister.InternalNames,
                                     violatingList.InterfaceLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.InterfaceRule.InternalConvention,
                                     node.Identifier.Text);
                return;
            }

        }
    }
}
