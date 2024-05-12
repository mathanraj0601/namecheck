using CLI.Engine.Lister;
using CLI.Engine;
using CLI.Model.TemplateRules;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CLI.Model.Lister
{
    public class ClassLister
    {
        public List<string> PrivateNames { get; set; }
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }
        public List<string> ProtectedNames { get; set; }


        public ClassLister()
        {
            PrivateNames = new List<string>();
            PublicNames = new List<string>();
            InternalNames = new List<string>();
            ProtectedNames = new List<string>();
           
        }

        public static void ListNames(ClassDeclarationSyntax node,
                                    TemplateLister followingList,
                                    TemplateLister violatingList,
                                    NamingConventionEngine namingConventionEngine,
                                    TemplateRule templateRules)
        {
            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PrivateKeyword)))
            {
                NameListerEngine.Get(followingList.ClassLister.PrivateNames,
                                      violatingList.ClassLister.PrivateNames,
                                      namingConventionEngine,
                                      templateRules.ClassRule.PrivateConvention,
                                        node.Identifier.Text);
                return;


            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.ClassLister.PublicNames,
                                     violatingList.ClassLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.ClassRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.ClassLister.InternalNames,
                                     violatingList.ClassLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.ClassRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.ProtectedKeyword)))
            {
                NameListerEngine.Get(followingList.ClassLister.ProtectedNames,
                                      violatingList.ClassLister.ProtectedNames,
                                      namingConventionEngine,
                                      templateRules.ClassRule.ProtectedConvention,
                                      node.Identifier.Text);
                return;
            }

            if (!node.Modifiers.Any())
            {
                NameListerEngine.Get(followingList.MethodLister.InternalNames,
                                     violatingList.ClassLister.InternalNames,
                                      namingConventionEngine,
                                      templateRules.ClassRule.InternalConvention,
                                      node.Identifier.Text);
                return;
            }

        }

       
    }
}
