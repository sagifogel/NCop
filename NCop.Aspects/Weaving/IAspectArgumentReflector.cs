using System;

namespace NCop.Aspects.Weaving
{
    internal interface IAspectArgumentReflector
    {
        Type ArgumentType { get; }
    }
}
