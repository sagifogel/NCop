using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeDefinition : MixinsTypeDefinition
    {
        protected readonly IEnumerable<Type> eventBrokersType = null;

        internal CompositeTypeDefinition(Type mixinsType, ITypeMap mixinsMap, IEnumerable<Type> eventBrokersType)
            : base(mixinsType, mixinsMap) {
            this.eventBrokersType = eventBrokersType;
        }

        protected override void CreateTypeDefinitions() {
            base.CreateTypeDefinitions();

            eventBrokersType.ForEach(eventBrokerType => {
                var typeDefinition = new EventBrokerTypeDefinition(eventBrokerType, TypeBuilder);

                typeDefinitions.Add(eventBrokerType, typeDefinition);
            });
        }

        protected override void EmitConstructorBody(ILGenerator ilGenerator) {
            base.EmitConstructorBody(ilGenerator);
        }
    }
}
