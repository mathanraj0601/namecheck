using CLI.Engine;
using CLI.Engine.Lister;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CLI.Model.TemplateRules;
using System.Collections.Generic;
using System.Linq;

namespace CLI.Model.Lister
{
    public class MethodLister
    {
        public List<string> PrivateNames { get; set; }
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }
        public List<string> ProtectedNames { get; set; }

        public MethodLister()
        {
            PrivateNames = new List<string>();
            PublicNames = new List<string>();
            InternalNames = new List<string>();
            ProtectedNames = new List<string>();
        }

        public static void ListNames(MethodDeclarationSyntax node,
                                    TemplateLister followingList ,
                                    TemplateLister violatingList,
                                    NamingConventionEngine namingConventionEngine, 
                                    TemplateRule templateRules)
        {
            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PrivateKeyword)))
            {
                NameListerEngine.Get(followingList.MethodLister.PrivateNames,
                                      violatingList.MethodLister.PrivateNames,
                                      namingConventionEngine,
                                      templateRules.MethodRule.PrivateConvention,
                                        node.Identifier.Text);
                return;


            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.MethodLister.PublicNames,
                                     violatingList.MethodLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.MethodRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.MethodLister.InternalNames,
                                     violatingList.MethodLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.MethodRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.ProtectedKeyword)))
            {
                NameListerEngine.Get(followingList.MethodLister.ProtectedNames,
                                      violatingList.MethodLister.ProtectedNames,
                                      namingConventionEngine,
                                      templateRules.MethodRule.ProtectedConvention,
                                      node.Identifier.Text);
                return;
            }

            if (!node.Modifiers.Any())
            {
                NameListerEngine.Get(followingList.MethodLister.PrivateNames,
                                     violatingList.MethodLister.PrivateNames,
                                      namingConventionEngine,
                                      templateRules.MethodRule.PrivateConvention,
                                      node.Identifier.Text);
                return;
            }

        }
    }
}
