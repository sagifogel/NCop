using System;

namespace NCop.Samples.MultipleMixins
{
    public class GuitarPlayerMixin : IMusician
    {
        public void Play() {
            Console.WriteLine("I am playing C# accord with Fender Telecaster");
        }
    }
}
