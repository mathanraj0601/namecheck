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
    public class RecordLister
    {
        public List<string> PublicNames { get; set; }
        public List<string> InternalNames { get; set; }

        public RecordLister()
        {
            PublicNames = new List<string>();
            InternalNames = new List<string>();
        }

        public static void ListNames(RecordDeclarationSyntax node,
                           TemplateLister followingList,
                           TemplateLister violatingList,
                           NamingConventionEngine namingConventionEngine,
                           TemplateRule templateRules)
        {


            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PublicKeyword)))
            {
                NameListerEngine.Get(followingList.RecordLister.PublicNames,
                                     violatingList.RecordLister.PublicNames,
                                     namingConventionEngine,
                                     templateRules.RecordRule.PublicConvention,
                                      node.Identifier.Text);
                return;
            }

            if (node.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.InternalKeyword)))
            {
                NameListerEngine.Get(followingList.RecordLister.InternalNames,
                                     violatingList.RecordLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.RecordRule.InternalConvention,
                                     node.Identifier.Text);
                return;

            }



            if (!node.Modifiers.Any())
            {
                NameListerEngine.Get(followingList.RecordLister.InternalNames,
                                     violatingList.RecordLister.InternalNames,
                                     namingConventionEngine,
                                     templateRules.RecordRule.InternalConvention,
                                     node.Identifier.Text);
                return;
            }

        }
    }
}
