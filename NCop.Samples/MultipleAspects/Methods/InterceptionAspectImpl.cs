using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Methods
{
    public class InterceptionAspectImpl : ActionInterceptionAspect
    {
        public override void OnInvoke(ActionInterceptionArgs args) {
            Console.WriteLine("OnInvoke");
            base.OnInvoke(args);
        }
    }
}
