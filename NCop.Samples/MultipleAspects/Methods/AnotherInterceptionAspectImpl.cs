using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Methods
{
    public class AnotherInterceptionAspectImpl : ActionInterceptionAspect
    {
        public override void OnInvoke(ActionInterceptionArgs args) {
            Console.WriteLine("OnInvoke of AnotherInterceptionAspect");
            base.OnInvoke(args);
        }
    }
}
