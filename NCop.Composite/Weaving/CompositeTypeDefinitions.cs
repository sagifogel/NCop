using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Exceptions;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using NCop.Weaving.Properties;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeDefinition : MixinsTypeDefinition, ICompositeTypeDefinition
    {
        protected readonly IDictionary<string, IFieldBuilderDefinition> eventTypeDefinitions = new Dictionary<string, IFieldBuilderDefinition>();

        internal CompositeTypeDefinition(Type mixinsType, ITypeMap mixinsMap)
            : base(mixinsType, mixinsMap) {
        }

        protected override void CreateTypeDefinitions() {
            var typeDefinitionsActions = new List<Action<TypeMap>>();

            RegisterTypeDefinitionMixinAction(typeDefinitionsActions);
            RegisterEventTypeDefinitionAction(typeDefinitionsActions);
            CreateTypeDefinitions(typeDefinitionsActions);
        }

        protected void RegisterTypeDefinitionMixinAction(List<Action<TypeMap>> typeDefinitionsActions) {
            typeDefinitionsActions.Add(mixin => {
                var mixinTypeDefinition = new MixinFieldBuilderDefinition(mixin.ContractType, TypeBuilder);

                typeDefinitions.Add(mixin.ContractType, mixinTypeDefinition);
            });
        }

        protected virtual void RegisterEventTypeDefinitionAction(List<Action<TypeMap>> typeDefinitionsActions) {
            typeDefinitionsActions.Add(mixin => {
                IEnumerable<EventBrokerFieldTypeDefinition> eventBrokerFieldTypeDefinitions;

                if (EventBrokerFieldTypeDefinitionsResolver.TryResolve(mixin.ContractType, TypeBuilder, out eventBrokerFieldTypeDefinitions)) {
                    eventBrokerFieldTypeDefinitions.ForEach(eventBrokerFieldTypeDefinition => {
                        eventTypeDefinitions.Add(eventBrokerFieldTypeDefinition.Name, eventBrokerFieldTypeDefinition);
                    });
                }
            });
        }

        private void CreateTypeDefinitions(List<Action<TypeMap>> typeDefinitionsActions) {
            mixinsMap.ForEach(map => {
                typeDefinitionsActions.ForEach(action => {
                    action(map);
                });
            });
        }

        protected override void EmitConstructorBody(ILGenerator ilGenerator) {
            base.EmitConstructorBody(ilGenerator);
        }

        public FieldBuilder GetEventFieldBuilder(string name, Type type) {
            IFieldBuilderDefinition fieldBuilderDefinition;

            if (!eventTypeDefinitions.TryGetValue(name, out fieldBuilderDefinition)) {
                throw new MissingFieldBuilderException(Resources.CouldNotFindFieldBuilderByType.Fmt(type.FullName));
            }
            else if (!ReferenceEquals(type, fieldBuilderDefinition.Type)) {
                var message = Resources.CouldNotFindFieldBuilderByType.Fmt(fieldBuilderDefinition.Type.FullName);

                throw new MissingFieldBuilderException(message);
            }

            return fieldBuilderDefinition.FieldBuilder;
        }
    }
}
