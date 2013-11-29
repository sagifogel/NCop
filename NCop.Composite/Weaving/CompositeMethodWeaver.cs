using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeMethodWeaver : AbstractMethodWeaver
    {
        private readonly AspectMethodWeaver methodWeaver = null;

        internal CompositeMethodWeaver(IAspectDefinitionCollection aspectDefinition, MethodInfo methodInfoImpl, Type implementationType, Type contractType)
            : base(methodInfoImpl, implementationType, contractType) {
            methodWeaver = new AspectMethodWeaver(aspectDefinition, methodInfoImpl, implementationType, contractType);
            MethodDefintionWeaver = methodWeaver.MethodDefintionWeaver;
            MethodScopeWeaver = methodWeaver.MethodScopeWeaver;
            MethodEndWeaver = methodWeaver.MethodEndWeaver;
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return MethodDefintionWeaver.Weave(MethodInfoImpl, typeDefinition);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
        }
    }
}
