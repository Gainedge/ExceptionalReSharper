using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using ReSharper.ExceptionalEnhanced.Models;

namespace ReSharper.ExceptionalEnhanced.Highlightings
{
    [RegisterConfigurableSeverity(
                                     Id,
                                     Constants.CompoundName,
                                     HighlightingGroupIds.BestPractice,
                                     "Exceptional.ExceptionNotDocumentedOptional",
                                     "Exceptional.ExceptionNotDocumentedOptional",
                                     Severity.HINT)]
    [ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
    public class ExceptionNotDocumentedOptionalHighlighting : HighlightingBase
    {
        #region constants

        public const string Id = "ExceptionNotDocumentedOptional";

        #endregion

        public string ExceptionTypeName {
          get {
            var exceptionType = ThrownException.ExceptionType;
            var exceptionTypeName = exceptionType != null ? exceptionType.GetClrName().ShortName : "[NOT RESOLVED]";
            return exceptionTypeName;
          }
        }

        #region constructors and destructors

        /// <summary>Initializes a new instance of the <see cref="ExceptionNotDocumentedOptionalHighlighting" /> class. </summary>
        /// <param name="thrownException">The thrown exception. </param>
        internal ExceptionNotDocumentedOptionalHighlighting(ThrownExceptionModel thrownException)
        {
            ThrownException = thrownException;
        }

        #endregion

        #region properties

        /// <summary>Gets the message which is shown in the editor. </summary>
        protected override string Message => Constants.OptionalPrefix + string.Format(Resources.HighlightNotDocumentedExceptions, this.ExceptionTypeName);

        /// <summary>Gets the thrown exception. </summary>
        internal ThrownExceptionModel ThrownException { get; }

        #endregion
    }
}