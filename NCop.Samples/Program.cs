using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples
{
    public class CSharpDeveloper : IDeveloper
    {
        public void Develop() {
            Console.WriteLine("Developing C#");
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloper))]
    public interface IDeveloper
    {
        void Develop();
    }

    class Program
    {
        static void Main(string[] args) {
            IDeveloper developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.TryResolve<IDeveloper>();
            developer.Develop();
        }
    }
}