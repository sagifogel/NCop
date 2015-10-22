using System;

namespace NCop.Samples.FirstAspect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
