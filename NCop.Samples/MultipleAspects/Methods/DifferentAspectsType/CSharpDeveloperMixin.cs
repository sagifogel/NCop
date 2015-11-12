using System;

namespace NCop.Samples.MultipleAspects.Methods.DifferentAspectsType
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
