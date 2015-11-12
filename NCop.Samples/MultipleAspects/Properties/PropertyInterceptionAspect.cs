using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Properties
{
    public class PropertyInterceptionAspect : PropertyInterceptionAspect<string>
    {
        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnGetValue of PropertyInterceptionAspect");
            args.ProceedGetValue();
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnSetValue of PropertyInterceptionAspect");
            args.ProceedSetValue();
        }
    }
}
