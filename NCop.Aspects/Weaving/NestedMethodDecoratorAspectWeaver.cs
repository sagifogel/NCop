using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodDecoratorAspectWeaver : OptionalByRefParamsMethodDecoratorWeaver, IAspectWeaver
    {
        internal NestedMethodDecoratorAspectWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings) {
        }
    }
}
