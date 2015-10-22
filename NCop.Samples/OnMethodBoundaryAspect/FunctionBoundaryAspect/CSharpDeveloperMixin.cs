using System;

namespace NCop.Samples.OnMethodBoundaryAspect.FunctionBoundaryAspect
{   
    public class CSharpDeveloperMixin : IDeveloper
    {
        public string Code() {
            return "C# coding";
        }
    }
}
