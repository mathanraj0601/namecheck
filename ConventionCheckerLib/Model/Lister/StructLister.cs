using CLI.Engine.Lister;
using CLI.Engine;
using CLI.Model.TemplateRules;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace CLI.Model.Lister
{
    public class StructLister
    {
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }

        public StructLister() {
            PublicNames = new List<string>();
            InternalNames = new List<string>();
        }

        public static void ListNames(StructDeclarationSyntax node,
                            TemplateLister followingList,
                            TemplateLister violatingList,
                            NamingConventionEngine namingConventionEngine,
                            TemplateRule templateRules)
        {


            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.StructLister.PublicNames,
                                     violatingList.StructLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.StructRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.StructLister.InternalNames,
                                     violatingList.StructLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.StructRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }

            

            if (!node.Modifiers.Any())
            {
                    NameListerEngine.Get(followingList.StructLister.InternalNames,
                                         violatingList.StructLister.InternalNames,
                                         namingConventionEngine,
                                         templateRules.StructRule.InternalConvention,
                                         node.Identifier.Text);
                    return;
            }

        }
    }
}
