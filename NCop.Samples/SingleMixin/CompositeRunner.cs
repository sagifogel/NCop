using NCop.Composite.Framework;
using NCop.Composite.Runtime;

namespace NCop.Samples.SingleMixin
{
    public static class CompositeRunner
    {
        public static void Run() {
            IPerson person = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IPerson) }
            });

            container.Configure();
            person = container.Resolve<IPerson>();
            person.Code();
        }
    }
}
