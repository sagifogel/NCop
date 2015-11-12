using System;

namespace NCop.Samples.MultipleAspects.Methods.SameAspectType
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
