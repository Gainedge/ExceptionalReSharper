﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;
using JetBrains.ReSharper.Psi;
using JetBrains.Util.Logging;

namespace ReSharper.ExceptionalContinued.Settings
{
    [SettingsKey(typeof(EnvironmentSettings), "Exceptional Settings")]
    public class ExceptionalSettings
    {
        public const string DefaultOptionalExceptions = @"
-- Contracts
System.ArgumentException,InvocationOnly
System.InvalidOperationException,InvocationOnly
System.FormatException,InvocationOnly

System.Collections.Generic.KeyNotFoundException,InvocationOnly
System.IndexOutOfRangeException,InvocationOnly
System.IO.PathTooLongException,InvocationOnly

System.NotSupportedException,InvocationOnly
System.NotImplementedException,ThrowOnly

-- Unit testing
Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException,InvocationOnly";

        public const string DefaultOptionalMethodExceptions = @"
System.Collections.IDictionary.Add,System.NotSupportedException
System.Nullable.Value,System.InvalidOperationException
System.Windows.DependencyObject.GetValue,System.InvalidOperationException
System.Windows.DependencyObject.SetValue,System.InvalidOperationException
System.Console.WriteLine,System.IO.IOException
System.Linq.Enumerable.Count,System.OverflowException";

        public const string DefaultAccessorOverrides = @"
System.Collections.Generic.Dictionary.Item,System.Collections.Generic.KeyNotFoundException,get";

        private List<OptionalExceptionConfiguration>       optionalExceptionsCache;
        private List<OptionalMethodExceptionConfiguration> optionalMethodExceptionsCache;
        private List<ExceptionAccessorOverride>            exceptionAccessorOverridesCache;

        [SettingsEntry(true, "Inspect public methods")]
        public bool InspectPublicMethods { get; set; }

        [SettingsEntry(true, "Inspect internal methods")]
        public bool InspectInternalMethods { get; set; }

        [SettingsEntry(true, "Inspect protected methods")]
        public bool InspectProtectedMethods { get; set; }

        [SettingsEntry(false, "Inspect private methods")]
        public bool InspectPrivateMethods { get; set; }

        [SettingsEntry(true, "Delegate invocations may throw System.Exception")]
        public bool DelegateInvocationsMayThrowExceptions { get; set; }

        [SettingsEntry(false, "Is documentation of exception subtype sufficient for throw statements")]
        public bool IsDocumentationOfExceptionSubtypeSufficientForThrowStatements { get; set; }

        [SettingsEntry(false, "Is documentation of exception subtype sufficient for reference expressions")]
        public bool IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions { get; set; }

        [SettingsEntry("", "Optional exceptions")]
        public string OptionalExceptions2 { get; set; }

        [SettingsEntry(true, "Use default optional exceptions")]
        public bool UseDefaultOptionalExceptions2 { get; set; }

        [SettingsEntry("", "Optional method exceptions")]
        public string OptionalMethodExceptions2 { get; set; }

        [SettingsEntry(true, "Use default optional method exceptions")]
        public bool UseDefaultOptionalMethodExceptions2 { get; set; }

        [SettingsEntry("Tests", "Namespaces that will be excluded from analysis")]
        public string IgnoredNamespaces { get; set; }

        [SettingsEntry("", "Accessor overrides")]
        public string AccessorOverrides2 { get; set; }

        [SettingsEntry(true, "Use default accessor overrides")]
        public bool UseDefaultAccessorOverrides2 { get; set; }

        public void InvalidateCaches()
        {
            lock (typeof(ExceptionalSettings))
            {
                optionalExceptionsCache       = null;
                optionalMethodExceptionsCache = null;
            }
        }

        public IEnumerable<OptionalExceptionConfiguration> GetOptionalExceptions()
        {
            if (optionalExceptionsCache == null)
            {
                lock (typeof(ExceptionalSettings))
                {
                    if (optionalExceptionsCache == null)
                    {
                        optionalExceptionsCache = LoadOptionalExceptions();
                    }
                }
            }

            return optionalExceptionsCache;
        }

        public IEnumerable<OptionalMethodExceptionConfiguration> GetOptionalMethodExceptions()
        {
            if (optionalMethodExceptionsCache == null)
            {
                lock (typeof(ExceptionalSettings))
                {
                    if (optionalMethodExceptionsCache == null)
                    {
                        optionalMethodExceptionsCache = LoadOptionalMethodExceptions();
                    }
                }
            }

            return optionalMethodExceptionsCache;
        }

        public IEnumerable<ExceptionAccessorOverride> GetExceptionAccessorOverrides()
        {
            if (exceptionAccessorOverridesCache == null)
            {
                lock (typeof(ExceptionalSettings))
                {
                    if (exceptionAccessorOverridesCache == null)
                    {
                        exceptionAccessorOverridesCache = LoadExceptionAccessorOverrides();
                    }
                }
            }

            return exceptionAccessorOverridesCache;
        }

        private List<OptionalExceptionConfiguration> LoadOptionalExceptions()
        {
            var list = new List<OptionalExceptionConfiguration>();
            var value = UseDefaultOptionalExceptions2
                            ? OptionalExceptions2 + DefaultOptionalExceptions
                            : OptionalExceptions2;
            foreach (var line in value.Replace("\r", "").Split('\n').Where(n => !string.IsNullOrEmpty(n)))
            {
                var optionalException = TryLoadOptionalException(line);
                if (optionalException != null)
                {
                    list.Add(optionalException);
                }
            }

            return list;
        }

        private List<OptionalMethodExceptionConfiguration> LoadOptionalMethodExceptions()
        {
            var list = new List<OptionalMethodExceptionConfiguration>();
            var value = UseDefaultOptionalMethodExceptions2
                            ? OptionalMethodExceptions2 + DefaultOptionalMethodExceptions
                            : OptionalMethodExceptions2;
            foreach (var line in value.Replace("\r", "").Split('\n').Where(n => !string.IsNullOrEmpty(n)))
            {
                var excludedMethodException = TryLoadOptionalMethodException(line);
                if (excludedMethodException != null)
                {
                    list.Add(excludedMethodException);
                }
            }

            return list;
        }

        private List<ExceptionAccessorOverride> LoadExceptionAccessorOverrides()
        {
            var list = new List<ExceptionAccessorOverride>();
            var value = UseDefaultAccessorOverrides2
                            ? AccessorOverrides2 + DefaultAccessorOverrides
                            : AccessorOverrides2;
            foreach (var line in value.Replace("\r", "").Split('\n').Where(n => !string.IsNullOrEmpty(n)))
            {
                var exceptionAccessorOverride = TryExceptionAccessorOverride(line);
                if (exceptionAccessorOverride != null)
                {
                    list.Add(exceptionAccessorOverride);
                }
            }

            return list;
        }

        private static OptionalExceptionConfiguration TryLoadOptionalException(string line)
        {
            try
            {
                var arr = line.Split(',');
                if (arr.Length == 2)
                {
                    var exceptionType = TypeFactory.CreateTypeByCLRName(arr[0], ServiceLocator.StageProcess.PsiModule);

                    if (Enum.TryParse(arr[1], out OptionalExceptionReplacementType replacementType))
                    {
                        return new OptionalExceptionConfiguration(exceptionType, replacementType);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException($"[Exceptional] Error loading optional exception '{line}'", ex);
            }

            return null;
        }

        private static OptionalMethodExceptionConfiguration TryLoadOptionalMethodException(string line)
        {
            var arr = line.Split(',');
            return arr.Length == 2 ? new OptionalMethodExceptionConfiguration(arr[0], arr[1]) : null;
        }

        private static ExceptionAccessorOverride TryExceptionAccessorOverride(string line)
        {
            var arr = line.Split(',');
            return arr.Length == 3 ? new ExceptionAccessorOverride(arr[0], arr[1], arr[2]) : null;
        }
    }
}