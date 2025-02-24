using System.Collections.Generic;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using ReSharper.ExceptionalContinued.Analyzers;

namespace ReSharper.ExceptionalContinued.Models.ExceptionsOrigins
{
    internal sealed class ObjectCreationExpressionModel : ExpressionExceptionsOriginModelBase<IObjectCreationExpression>
    {
        #region member vars

        private IEnumerable<ThrownExceptionModel> _thrownExceptions;

        #endregion

        #region constructors and destructors

        public ObjectCreationExpressionModel(IAnalyzeUnit analyzeUnit, IObjectCreationExpression objectCreationExpression, IBlockModel containingBlock) : base(
            analyzeUnit,
            objectCreationExpression,
            containingBlock)
        {
        }

        #endregion

        #region methods

        /// <summary>Runs the analyzer against all defined elements. </summary>
        /// <param name="analyzer">The analyzer. </param>
        public override void Accept(AnalyzerBase analyzer)
        {
            foreach (var thrownExceptionModel in ThrownExceptions)
            {
                thrownExceptionModel.Accept(analyzer);
            }
        }

        #endregion

        #region properties

        /// <summary>Gets a list of exceptions which may be thrown from this reference expression. </summary>
        public override IEnumerable<ThrownExceptionModel> ThrownExceptions
        {
            get
            {
                if (_thrownExceptions == null)
                {
                    _thrownExceptions = ThrownExceptionsReader.Read(AnalyzeUnit, this);
                }
                return _thrownExceptions;
            }
        }

        #endregion
    }
}