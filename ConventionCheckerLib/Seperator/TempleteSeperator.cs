using CLI.Engine;
using CLI.Engine.Lister;
using CLI.Model.Lister;
using CLI.Model.TemplateRules;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CLI.Seperator
{
    public class TempleteSeperator : CSharpSyntaxWalker
    {
        public TemplateLister FollowingList { get; set; }
        public TemplateLister ViolatingList { get; set; }
        private readonly TemplateRule _templateRules;
        private readonly NamingConventionEngine _namingConventionEngine;
        public TempleteSeperator(TemplateRule templateRules)
        {
            _templateRules = templateRules;
            _namingConventionEngine = new NamingConventionEngine();
            FollowingList = new TemplateLister("Default");
            ViolatingList = new TemplateLister("Default");
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            ClassLister.ListNames(node, FollowingList,ViolatingList,_namingConventionEngine,_templateRules);
            base.VisitClassDeclaration(node);
        }

        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            DelegateLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitDelegateDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            MethodLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitMethodDeclaration(node);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            NameSpaceLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitNamespaceDeclaration(node);
        }

        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            StructLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitStructDeclaration(node);
        }

       
        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            FieldLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitFieldDeclaration(node);
        }

        public override void VisitRecordDeclaration(RecordDeclarationSyntax node)
        {
            RecordLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitRecordDeclaration(node);
        }

        public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            
            VariableLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitVariableDeclarator(node);
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            PropertyLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitPropertyDeclaration(node);
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            EnumLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitEnumDeclaration(node);
        }

        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            InterfaceLister.ListNames(node, FollowingList, ViolatingList, _namingConventionEngine, _templateRules);
            base.VisitInterfaceDeclaration(node);
        }

        
    }


}
