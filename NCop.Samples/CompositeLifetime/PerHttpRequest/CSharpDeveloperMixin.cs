using System;

namespace NCop.Samples.CompositeLifetime.PerHttpRequest
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
