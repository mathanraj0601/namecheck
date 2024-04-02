﻿using CLI.Engine.Lister;
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
    public class EnumLister
    {
        public List<string> Names { get; set; }
        public EnumLister() { 
            Names = new List<string>();
        }

        public static void ListNames(EnumDeclarationSyntax node,
                      TemplateLister followingList,
                      TemplateLister violatingList,
                      NamingConventionEngine namingConventionEngine,
                      TemplateRule templateRules)
        {

            NameListerEngine.Get(followingList.EnumLister.Names,
                                  violatingList.EnumLister.Names,
                                  namingConventionEngine,
                                  templateRules.EnumRule.Convention,
                                  node.Identifier.Text);
            return;


        }
    }
}