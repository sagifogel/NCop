using System;

namespace NCop.Samples.DisposingComposites
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public void Code() {
            Console.WriteLine("C# coding");
        }

        public void Dispose() {
            Console.WriteLine("Disposing CSharpDeveloperMixin");
        }
    }
}
