using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;

namespace NCop.Samples.EventInterceptionAspect.EventActionInterceptionAspect
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            Action<string> codeCompletionAction = (code) => Console.WriteLine(code);
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.OnCodeCompleted += codeCompletionAction;
            developer.Code("C# coding");
            developer.OnCodeCompleted -= codeCompletionAction;
        }
    }
}
