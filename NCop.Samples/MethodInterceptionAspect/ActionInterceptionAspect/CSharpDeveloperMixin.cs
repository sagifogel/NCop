using System;

namespace NCop.Samples.MethodInterceptionAspect.ActionInterceptionAspect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code(string code) {
            Console.WriteLine(code);
        }
    }
}
