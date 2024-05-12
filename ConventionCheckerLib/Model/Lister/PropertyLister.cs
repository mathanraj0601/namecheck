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
    public class PropertyLister
    {
        public List<string> PrivateNames { get; set; }
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }
        public List<string> ProtectedNames { get; set; }


        public PropertyLister()
        {
            PrivateNames = new List<string>();
            PublicNames = new List<string>();
            InternalNames = new List<string>();
            ProtectedNames = new List<string>();
        }

        public static void ListNames(PropertyDeclarationSyntax node,
                                 TemplateLister followingList,
                                 TemplateLister violatingList,
                                 NamingConventionEngine namingConventionEngine,
                                 TemplateRule templateRules)
        {
            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PrivateKeyword)))
            {
                NameListerEngine.Get(followingList.PropertyLister.PrivateNames,
                                      violatingList.PropertyLister.PrivateNames,
                                      namingConventionEngine,
                                      templateRules.PropertyRule.PrivateConvention,
                                        node.Identifier.Text);
                return;


            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.PropertyLister.PublicNames,
                                     violatingList.PropertyLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.PropertyRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.PropertyLister.InternalNames,
                                     violatingList.PropertyLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.PropertyRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.ProtectedKeyword)))
            {
                NameListerEngine.Get(followingList.PropertyLister.ProtectedNames,
                                      violatingList.PropertyLister.ProtectedNames,
                                      namingConventionEngine,
                                      templateRules.PropertyRule.ProtectedConvention,
                                      node.Identifier.Text);
                return;
            }

            if (!node.Modifiers.Any())
            {
                NameListerEngine.Get(followingList.PropertyLister.PrivateNames,
                                     violatingList.PropertyLister.PrivateNames,
                                      namingConventionEngine,
                                      templateRules.PropertyRule.PrivateConvention,
                                      node.Identifier.Text);
                return;
            }

        }
    }
}
