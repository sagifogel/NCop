using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper : IDisposable
    {
        void Code();
    }


    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
        }

        [MethodInterceptionAspect(typeof(SimpleActionInterceptionAspect))]
        public void Dispose() {
        }
    }

    public class SimpleActionInterceptionAspect : ActionInterceptionAspect
    {
        public override void OnInvoke(ActionInterceptionArgs args) {
            Console.WriteLine("OnInvoke");
            args.Proceed();
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
            developer.Dispose();
        }
    }
}