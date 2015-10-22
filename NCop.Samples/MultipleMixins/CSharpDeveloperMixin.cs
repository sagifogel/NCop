using System;

namespace NCop.Samples.MultipleMixins
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }
    }
}
