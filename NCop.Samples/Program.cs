using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples
{   
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C#");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IDeveloper developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.TryResolve<IDeveloper>();
            developer.Code();
        }
    }
}