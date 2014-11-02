using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodDecoratorBindingWeaver(BindingSettings bindingSettings, IAspectMethodWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
			: base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
