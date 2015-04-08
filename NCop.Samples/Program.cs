using System;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples
{
    [TransientComposite(Disposable = true)]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper : IDisposable
    {
        void Code();
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }

        public void Dispose() {
            Console.WriteLine("Disposing CSharpDeveloperMixin");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IDeveloper developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code();
            container.Dispose();
        }
    }
}