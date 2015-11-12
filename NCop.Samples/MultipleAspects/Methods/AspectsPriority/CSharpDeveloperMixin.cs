using System;

namespace NCop.Samples.MultipleAspects.Methods.AspectsPriority
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
