﻿using JetBrains.Application.Settings;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.DataFlow;
using JetBrains.IDE.UI.Extensions;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using JetBrains.Rd.Base;
using ReSharper.ExceptionalContinued.Settings;

namespace ReSharper.ExceptionalContinued.Options
{
    [OptionsPage("Exceptional::IgnoredNamespaces", "Ignored Namespaces", typeof(UnnamedThemedIcons.ExceptionalSettings),
                 ParentId = ExceptionalOptionsPage.Pid, Sequence = 6.0)]
    public class NamespacesToIgnoreOptionsPage : BeSimpleOptionsPage
    {
        public NamespacesToIgnoreOptionsPage(Lifetime lifetime, OptionsPageContext optionsPageContext,
                                             OptionsSettingsSmartContext optionsSettingsSmartContext,
                                             bool wrapInScrollablePanel = true) : base(lifetime, optionsPageContext,
            optionsSettingsSmartContext, wrapInScrollablePanel)
        {
            _ = AddText(DefaultResource.OptionsPage_NamespacesToIgnore_Text);
            _ = AddText(DefaultResource.OptionsPage_NamespacesToIgnore_Explanation);
            CreateRichTextNamespacesToIgnore(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
        }

        private void CreateRichTextNamespacesToIgnore(Lifetime                       lifetime,
                                                      IContextBoundSettingsStoreLive storeOptionsTransactionContext)
        {
            IProperty<string> property = new Property<string>(lifetime, "Exceptional::IgnoredNamespaces::Namespaces");
            _ = property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionalSettings key) =>
                                                                              key.IgnoredNamespaces));
            property.Change.Advise(lifetime, a =>
                                             {
                                                 if (!a.HasNew)
                                                 {
                                                     return;
                                                 }

                                                 storeOptionsTransactionContext
                                                    .SetValue((ExceptionalSettings key) => key.IgnoredNamespaces,
                                                              a.New);
                                             });
            var textControl = BeControls.GetTextControl(isReadonly: false);
            textControl.Text.SetValue(property.GetValue());
            textControl.Text.Change.Advise(lifetime,
                                           str =>
                                           {
                                               storeOptionsTransactionContext
                                                  .SetValue((ExceptionalSettings key) => key.IgnoredNamespaces, str);
                                           });
            AddControl(textControl);
        }
    }
}