using JetBrains.ReSharper.Psi.Modules;
using JetBrains.ReSharper.Psi.Tree;
using ReSharper.ExceptionalEnhanced.Analyzers;

namespace ReSharper.ExceptionalEnhanced.Models
{
    internal interface IAnalyzeUnit : IBlockModel
    {
        #region methods

        void Accept(AnalyzerBase analyzer);

        IPsiModule GetPsiModule();

        #endregion

        #region properties

        DocCommentBlockModel DocumentationBlock { get; set; }

        bool IsInspectionRequired { get; }

        ITreeNode Node { get; }

        #endregion
    }
}