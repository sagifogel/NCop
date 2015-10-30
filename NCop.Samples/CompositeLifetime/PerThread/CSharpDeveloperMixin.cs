using System;

namespace NCop.Samples.CompositeLifetime.PerThread
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
