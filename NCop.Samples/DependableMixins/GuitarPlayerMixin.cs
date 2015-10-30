using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Samples.DependableMixins
{
    public class GuitarPlayerMixin : IMusician
    {
        public void Play() {
            Console.WriteLine("I am playing C# accord with Fender Telecaster");
        }
    }
}
