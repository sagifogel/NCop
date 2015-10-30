using System;

namespace NCop.Samples.CompositeLifetime.Transient
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
