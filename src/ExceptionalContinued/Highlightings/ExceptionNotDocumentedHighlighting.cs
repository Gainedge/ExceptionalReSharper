using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using ReSharper.ExceptionalEnhanced.Models;

namespace ReSharper.ExceptionalEnhanced.Highlightings
{
    [RegisterConfigurableSeverity(
                                     Id,
                                     Constants.CompoundName,
                                     HighlightingGroupIds.BestPractice,
                                     "Exceptional.ExceptionNotDocumented",
                                     "Exceptional.ExceptionNotDocumented",
                                     Severity.WARNING)]
    [ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
    public class ExceptionNotDocumentedHighlighting : ExceptionNotDocumentedOptionalHighlighting
    {
        #region constants

        public new const string Id = "ExceptionNotDocumented";

        #endregion

        #region constructors and destructors

        /// <summary>Initializes a new instance of the <see cref="ExceptionNotDocumentedHighlighting" /> class. </summary>
        /// <param name="thrownException">The thrown exception. </param>
        internal ExceptionNotDocumentedHighlighting(ThrownExceptionModel thrownException) : base(thrownException)
        {
        }

        #endregion

        #region properties

        /// <summary>Gets the message which is shown in the editor. </summary>
        protected override string Message => string.Format(Resources.HighlightNotDocumentedExceptions, this.ExceptionTypeName);

        #endregion
    }
}