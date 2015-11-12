using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Properties
{
    public class AnotherPropertyInterceptionAspect : PropertyInterceptionAspect<string>
    {
        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnGetValue of AnotherPropertyInterceptionAspect");
            args.ProceedGetValue();
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnSetValue of AnotherPropertyInterceptionAspect");
            args.ProceedSetValue();
        }
    }
}
