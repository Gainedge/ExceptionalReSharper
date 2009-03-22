/// <copyright>Copyright (c) 2009 CodeGears.net All rights reserved.</copyright>

using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace CodeGears.ReSharper.Exceptional.Model
{
    internal class CatchVariableModel : TreeElementModelBase<ICatchVariableDeclarationNode>
    {
        public ICSharpIdentifierNode VariableName
        {
            get { return this.Node.Name; }
        }

        public CatchVariableModel(IAnalyzeUnit analyzeUnit, ICatchVariableDeclarationNode catchVariableDeclaration)
            : base(analyzeUnit, catchVariableDeclaration)
        {
        }
    }
}