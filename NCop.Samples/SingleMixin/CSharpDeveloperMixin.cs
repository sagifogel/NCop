using System;

namespace NCop.Samples.SingleMixin
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
