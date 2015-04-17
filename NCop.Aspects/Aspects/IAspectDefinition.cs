using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition<TMember> : IAspectDefinition
    {
        TMember Member { get; }
    }
}
