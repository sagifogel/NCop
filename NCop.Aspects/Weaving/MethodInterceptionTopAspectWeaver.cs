using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
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
    internal class MethodInterceptionTopAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        internal MethodInterceptionTopAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, FieldInfo weavedType)
            : base(aspectDefinition, settings, weavedType) {
            var @params = weavingSettings.MethodInfoImpl.GetParameters();

            argumentsWeavingSetings.Parameters = @params.Select(@param => @param.ParameterType).ToArray();
            argumentsWeaver = new MethodImplArgumentsWeaver(argumentsWeavingSetings, settings, localBuilderRepository);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            LocalBuilder bindingLocalBuilder = null;
            Type methodBindingWeaverBaseType = null;

            methodBindingWeaverBaseType = WeavedType.ReflectedType.GetInterfaces().First();
            bindingLocalBuilder = ilGenerator.DeclareLocal(WeavedType.ReflectedType);
            localBuilderRepository.Add(methodBindingWeaverBaseType, bindingLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, WeavedType);
            ilGenerator.EmitStoreLocal(bindingLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);

            return weaver.Weave(ilGenerator);
        }
    }
}
