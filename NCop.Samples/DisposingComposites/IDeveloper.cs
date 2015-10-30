using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples.DisposingComposites
{
    [TransientComposite(Disposable = true)]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper : IDisposable
    {
        void Code();
    }
}
