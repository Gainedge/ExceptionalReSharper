﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReSharper.ExceptionalContinued {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ReSharper.ExceptionalContinued.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage of catch-all clauses is not recommended [Exceptional].
        /// </summary>
        internal static string HighlightCatchAllClauses {
            get {
                return ResourceManager.GetString("HighlightCatchAllClauses", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Possible &apos;System.Exception&apos; from delegate invocation is not documented [Exceptional].
        /// </summary>
        internal static string HighlightEventNotDocumentedExceptions {
            get {
                return ResourceManager.GetString("HighlightEventNotDocumentedExceptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exception &apos;{0}&apos; is not documented [Exceptional].
        /// </summary>
        internal static string HighlightNotDocumentedExceptions {
            get {
                return ResourceManager.GetString("HighlightNotDocumentedExceptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exception &apos;{0}&apos; is not thrown [Exceptional].
        /// </summary>
        internal static string HighlightNotThrownDocumentedExceptions {
            get {
                return ResourceManager.GetString("HighlightNotThrownDocumentedExceptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Swallowing exceptions in catch-all clause is not recommended [Exceptional].
        /// </summary>
        internal static string HighlightSwallowingExceptions {
            get {
                return ResourceManager.GetString("HighlightSwallowingExceptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Caught exception should be passed as inner exception [Exceptional].
        /// </summary>
        internal static string HighlightThrowingFromCatchWithoutInnerException {
            get {
                return ResourceManager.GetString("HighlightThrowingFromCatchWithoutInnerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Throwing &apos;System.Exception&apos; is not recommended [Exceptional].
        /// </summary>
        internal static string HighlightThrowingSystemException {
            get {
                return ResourceManager.GetString("HighlightThrowingSystemException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add namespaces that will not be analysed..
        /// </summary>
        internal static string Options_Exclusions_Description {
            get {
                return ResourceManager.GetString("Options.Exclusions.Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch exception &apos;{0}&apos; [Exceptional].
        /// </summary>
        internal static string QuickFixCatchException {
            get {
                return ResourceManager.GetString("QuickFixCatchException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Include caught exception as inner exception [Exceptional].
        /// </summary>
        internal static string QuickFixIncludeInnerException {
            get {
                return ResourceManager.GetString("QuickFixIncludeInnerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add documentation for exception &apos;{0}&apos; [Exceptional].
        /// </summary>
        internal static string QuickFixInsertExceptionDocumentation {
            get {
                return ResourceManager.GetString("QuickFixInsertExceptionDocumentation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove unnecessary exception documentation [Exceptional].
        /// </summary>
        internal static string QuickFixRemoveExceptionDocumentation {
            get {
                return ResourceManager.GetString("QuickFixRemoveExceptionDocumentation", resourceCulture);
            }
        }
    }
}
