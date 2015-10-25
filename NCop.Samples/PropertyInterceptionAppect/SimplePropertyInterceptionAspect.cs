using System;
using NCop.Aspects.Framework;

namespace NCop.Samples.PropertyInterceptionAppect
{
    public class SimplePropertyInterceptionAspect : PropertyInterceptionAspect<string>
    {
        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnGetValue", args.Property.Name);
            args.ProceedGetValue();
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            Console.WriteLine("OnSetValue {0}", args.Property.Name);
            Console.WriteLine("Value {0}", args.Value);
            args.ProceedSetValue();
        }
    }
}
