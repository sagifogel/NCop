using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Exceptions;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using NCop.Weaving.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeDefinition : MixinsTypeDefinition, IAspectTypeDefinition
    {
        protected readonly ICompositeMemberCollection compositeMemberCollection = null;
        protected readonly IDictionary<string, EventBrokerFieldTypeDefinition> eventTypeDefinitions = new Dictionary<string, EventBrokerFieldTypeDefinition>();

        internal CompositeTypeDefinition(Type mixinsType, ITypeMap mixinsMap, ICompositeMemberCollection compositeMemberCollection)
            : base(mixinsType, mixinsMap) {
            this.compositeMemberCollection = compositeMemberCollection;
        }

        protected override void CreateTypeDefinitions() {
            var typeDefinitionsActions = new List<Action<TypeMap>>();

            RegisterMixinsTypeDefinition(typeDefinitionsActions);
            RegisterEventTypeDefinitions();
            CreateTypeDefinitions(typeDefinitionsActions);
        }

        protected void RegisterMixinsTypeDefinition(List<Action<TypeMap>> typeDefinitionsActions) {
            typeDefinitionsActions.Add(mixin => {
                var mixinTypeDefinition = new MixinFieldBuilderDefinition(mixin.ContractType, TypeBuilder);

                typeDefinitions.Add(mixin.ContractType, mixinTypeDefinition);
            });
        }

        protected virtual void RegisterEventTypeDefinitions() {
            var eventsMap = compositeMemberCollection.Events.Where(eventMap => eventMap.HasAspectDefinitions);

            if (eventsMap.IsNotNullOrEmpty()) {
                var eventBrokerWeaver = new EventBrokerWeaver(TypeBuilder, eventsMap);
                var eventBrokerDefinitions = eventBrokerWeaver.Weave();

                eventBrokerDefinitions.ForEach(eventBrokerDefinition => {
                    eventTypeDefinitions.Add(eventBrokerDefinition.Name, eventBrokerDefinition);
                });
            }
        }

        private void CreateTypeDefinitions(List<Action<TypeMap>> typeDefinitionsActions) {
            mixinsMap.ForEach(map => {
                typeDefinitionsActions.ForEach(action => {
                    action(map);
                });
            });
        }

        public FieldBuilder GetEventFieldBuilder(string name, Type type) {
            var eventBrokerFieldTypeDefinition = GetEventBrokerFielTypeDefinition(name, eventBrokerDefinition => {
                return ReferenceEquals(eventBrokerDefinition.Type, type);
            });

            return eventBrokerFieldTypeDefinition.FieldBuilder;
        }

        public EventBrokerFieldTypeDefinition GetEventBrokerFielTypeDefinition(EventInfo @event) {
            return GetEventBrokerFielTypeDefinition(@event.Name, eventBrokerDefinition => {
                return @event.ToEventBrokerType() == eventBrokerDefinition.Type;
            });
        }

        private EventBrokerFieldTypeDefinition GetEventBrokerFielTypeDefinition(string name, Func<EventBrokerFieldTypeDefinition, bool> predicate) {
            EventBrokerFieldTypeDefinition eventBrokerFieldTypeDefinition;

            if (!eventTypeDefinitions.TryGetValue(name, out eventBrokerFieldTypeDefinition)) {
                throw new MissingFieldBuilderException(Resources.CouldNotFindFieldBuilderByType.Fmt(eventBrokerFieldTypeDefinition.Type.FullName));
            }

            if (!predicate(eventBrokerFieldTypeDefinition)) {
                var message = Resources.CouldNotFindFieldBuilderByType.Fmt(eventBrokerFieldTypeDefinition.Type.FullName);

                throw new MissingFieldBuilderException(message);
            }

            return eventBrokerFieldTypeDefinition;
        }

        public IEnumerable<EventBrokerFieldTypeDefinition> EventBrokerFieldTypeDefinitions {
            get {
                return eventTypeDefinitions.Values;
            }
        }
    }
}
