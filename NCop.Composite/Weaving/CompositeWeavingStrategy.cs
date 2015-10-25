using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeWeavingStrategy : MixinsWeaverStrategy
    {
        internal CompositeWeavingStrategy(IAspectTypeDefinition typeDefinition, ITypeMapCollection mixins, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry)
            : base(typeDefinition, mixins, methodWeavers, registry) {
        }

        protected override void EmitConstructorBody(ILGenerator ilGenerator) {
            var compositeTypeDefinition = (IAspectTypeDefinition)typeDefinition;

            base.EmitConstructorBody(ilGenerator);

            compositeTypeDefinition.EventBrokerFieldTypeDefinitions.ForEach(fieldTypeDefinition => {
                var contractType = fieldTypeDefinition.DeclaringType;
                var contractField = compositeTypeDefinition.GetFieldBuilder(contractType);
                var eventBrokerCtor = fieldTypeDefinition.EventBrokerType.GetConstructors()[0];
                var delegateCtor = fieldTypeDefinition.EventBrokerDelegateType.GetConstructor(new[] { typeof(object), typeof(IntPtr) });

                ilGenerator.EmitLoadArg(0);
                ilGenerator.EmitLoadArg(0);
                ilGenerator.Emit(OpCodes.Ldfld, contractField);
                ilGenerator.EmitLoadArg(0);
                ilGenerator.Emit(OpCodes.Ldftn, fieldTypeDefinition.InvokeMethodBuilder);
                ilGenerator.Emit(OpCodes.Newobj, delegateCtor);
                ilGenerator.Emit(OpCodes.Newobj, eventBrokerCtor);
                ilGenerator.Emit(OpCodes.Stfld, fieldTypeDefinition.FieldBuilder);
            });
        }
    }
}
