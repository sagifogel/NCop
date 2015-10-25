using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Core
{
    public class EventMapper : IEventMapper
    {
        private readonly List<IEventMap> mappedEvents = null;

        public EventMapper(ITypeMapCollection typeMap) {
            Func<EventInfo, bool> eventPredicate = eventdInfo => !eventdInfo.IsSpecialName;

            var mapped = typeMap.Select(map => new {
                ContractType = map.ServiceType,
                ImplementationType = map.ConcreteType,
                ContractEvents = map.ServiceType.GetPublicEvents().Where(eventPredicate),
                EventsImpl = map.ConcreteType.GetPublicEvents().ToSet(eventPredicate),
            });

            var mappedEventsEnumerable = mapped.SelectMany(map => {
                var events = map.ContractEvents;

                return events.Select(@event => {
                    var match = @event.SelectFirst(map.EventsImpl,
                                                  (c, impl) => c.GetAddMethod().IsMatchedTo(impl.GetAddMethod()),
                                                  (c, impl) => new {
                                                      EventImpl = impl,
                                                      ContractEvent = c
                                                  });

                    return new EventMap(map.ContractType,
                                        map.ImplementationType,
                                        match.ContractEvent,
                                        match.EventImpl);
                });
            });

            mappedEvents = mappedEventsEnumerable.ToListOf<IEventMap>();
        }

        public IEnumerator<IEventMap> GetEnumerator() {
            return mappedEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count {
            get {
                return mappedEvents.Count;
            }
        }
    }
}
