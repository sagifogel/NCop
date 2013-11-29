using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Engine
{
    public interface IHasAspectDefinitions
    {
        bool HasAspectDefinitions { get; }
        IAspectDefinitionCollection AspectDefinitions { get; }
    }
}
