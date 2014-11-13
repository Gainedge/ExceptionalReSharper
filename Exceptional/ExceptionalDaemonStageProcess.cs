using System;
using System.Collections.Generic;
using JetBrains.Application.Progress;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Daemon.CSharp.Stages;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using ReSharper.Exceptional.Settings;

namespace ReSharper.Exceptional
{
    /// <summary>This process is executed by the ReSharper's Daemon</summary>
    /// <remarks>The instance of this class is constructed each time the daemon needs to re highlight a given file. 
    /// This object is short-lived. It executes the target highlighting logic.</remarks>
    public class ExceptionalDaemonStageProcess : CSharpDaemonStageProcessBase
    {
        private readonly IDaemonProcess _process;
        private readonly List<HighlightingInfo> _hightlightings = new List<HighlightingInfo>();
        private readonly ExceptionalSettings _settings;

        public List<HighlightingInfo> Hightlightings
        {
            get { return _hightlightings; }
        }

        public ExceptionalDaemonStageProcess(IDaemonProcess process, ICSharpFile file, ExceptionalSettings settings)
            : base(process, file)
        {
            _process = process;
            _settings = settings;
        }

        public override void Execute(Action<DaemonStageResult> commiter)
        {
            var file = _process.SourceFile.GetTheOnlyPsiFile(CSharpLanguage.Instance) as ICSharpFile;
            if (file == null)
                return;

            var elementProcessor = new ExceptionalRecursiveElementProcessor(this, _process, _settings);
            file.ProcessDescendants(elementProcessor);

            if (_process.InterruptFlag)
                throw new ProcessCancelledException();

            commiter(new DaemonStageResult(Hightlightings));
        }
    }
}