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
    public class FieldLister
    {
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }
        public List<string> ProtectedNames { get; set; }
        public List<string> PrivateNames { get; set; }

        public FieldLister()
        {
            PublicNames = new List<string>();
            InternalNames = new List<string>();
            ProtectedNames = new List<string>();
            PrivateNames = new List<string>();
        }

        public static void ListNames(FieldDeclarationSyntax node,
                               TemplateLister followingList,
                               TemplateLister violatingList,
                               NamingConventionEngine namingConventionEngine,
                               TemplateRule templateRules)
        {

            foreach (var variable in node.Declaration.Variables)
            {
                if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PrivateKeyword)))
                {
                    NameListerEngine.Get(followingList.FieldLister.PrivateNames,
                                          violatingList.FieldLister.PrivateNames,
                                          namingConventionEngine,
                                          templateRules.FieldRule.PrivateConvention,
                                            variable.Identifier.Text);
                    return;


                }

                if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
                {
                    NameListerEngine.Get(followingList.FieldLister.PublicNames,
                                         violatingList.FieldLister.PublicNames,
                                         namingConventionEngine,
                                         templateRules.FieldRule.PublicConvention,
                                          variable.Identifier.Text);
                    return;
                }

                if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
                {
                    NameListerEngine.Get(followingList.FieldLister.InternalNames,
                                         violatingList.FieldLister.InternalNames,
                                         namingConventionEngine,
                                         templateRules.FieldRule.InternalConvention,
                                         variable.Identifier.Text);
                    return;

                }

                if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.ProtectedKeyword)))
                {
                    NameListerEngine.Get(followingList.FieldLister.ProtectedNames,
                                          violatingList.FieldLister.ProtectedNames,
                                          namingConventionEngine,
                                          templateRules.FieldRule.ProtectedConvention,
                                          variable.Identifier.Text);
                    return;
                }

                if (!node.Modifiers.Any())
                {
                    NameListerEngine.Get(followingList.PropertyLister.PrivateNames,
                                         violatingList.PropertyLister.PrivateNames,
                                          namingConventionEngine,
                                          templateRules.FieldRule.PrivateConvention,
                                           variable.Identifier.Text);
                    return;
                }
            }
        }
    }
}
