using System;

namespace NCop.Samples.OnMethodBoundaryAspect.ActionBoundaryAspect
{   
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
