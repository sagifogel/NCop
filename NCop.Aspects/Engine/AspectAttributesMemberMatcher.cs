using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using NCop.Core.Lib;

namespace NCop.Aspects.Engine
{
    public class AspectAttributesMemberMatcher : Tuples<MemberInfo, IAspectDefinitionCollection>
    {
        public AspectAttributesMemberMatcher(Type aspectDeclaringType, IAspectMemebrsCollection aspectMembersCollection) {
            var methodAspects = CollectMethodsAspectDefinitions(aspectDeclaringType, aspectMembersCollection);
            var propertiesAspects = CollectPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection);

            Values = methodAspects.Concat(propertiesAspects);
        }

        public IEnumerable<Tuple<MemberInfo, IAspectDefinitionCollection>> CollectMethodsAspectDefinitions(Type aspectDeclaringType, IAspectMethodMapCollection aspectMembersCollection) {
            return aspectMembersCollection.Methods.Select(aspectMembers => {
                IAspectDefinitionCollection aspectsCollection = null;
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return CollectMethodsAspectDefinitions(member, aspectDeclaringType, aspectMembers.Target);
                });

                aspectsCollection = new AspectDefinitionCollection(aspects);

                return Tuple.Create(aspectMembers.Target as MemberInfo, aspectsCollection);
            });
        }

        public IEnumerable<Tuple<MemberInfo, IAspectDefinitionCollection>> CollectPropertiesAspectDefinitions(Type aspectDeclaringType, IAspectPropertyMapCollection aspectMembersCollection) {
            var aspectDefinitionsCollection = new List<Tuple<MemberInfo, IAspectDefinitionCollection>>();

            CollectGetPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties, aspectDefinitionsCollection);
            CollectSetPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties, aspectDefinitionsCollection);

            return aspectDefinitionsCollection;
        }

        private IEnumerable<IAspectDefinition> CollectMethodsAspectDefinitions(MethodInfo member, Type aspectDeclaringType, MemberInfo target) {
            var onMethodBoundaryAspects = member.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
            var methodInterceptionAspects = member.GetCustomAttributes<MethodInterceptionAspectAttribute>();

            var onMethodBoundaryAspectDefinitions = onMethodBoundaryAspects.Select(aspect => {
                return new OnMethodBoundaryAspectDefinition(aspect, aspectDeclaringType, target);
            });

            var methodInterceptionAspectDefinitions = methodInterceptionAspects.Select(aspect => {
                return new MethodInterceptionAspectDefinition(aspect, aspectDeclaringType, target);
            });

            return methodInterceptionAspectDefinitions.Cast<IAspectDefinition>()
                                                      .Concat(onMethodBoundaryAspectDefinitions);
        }

        private void CollectGetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties, ICollection<Tuple<MemberInfo, IAspectDefinitionCollection>> tuples) {
            properties.ForEach(property => {
                var getMethodTarget = property.ContractMember.GetGetMethod();

                if (getMethodTarget.IsNotNull()) {
                    MemberInfo target = property.Target.GetGetMethod();
                    IAspectDefinitionCollection aspectsCollection = null;
                    var getPropertyInterceptionAspects = new List<IAspectDefinition>();

                    property.Members.ForEach(member => {
                        var getMethod = member.GetGetMethod();
                        var propertyInterceptionAspectsAttrs = member.GetCustomAttributes<PropertyInterceptionAspectAttribute>();

                        propertyInterceptionAspectsAttrs.ForEach(aspect => {
                            if (getMethod.IsNotNull()) {
                                var getPropertyAspect = new GetPropertyInterceptionAspectAttribute(aspect.AspectType) {
                                    AspectPriority = aspect.AspectPriority,
                                    LifetimeStrategy = aspect.LifetimeStrategy
                                };

                                getPropertyInterceptionAspects.Add(new GetPropertyInterceptionAspectDefinition(getPropertyAspect, aspectDeclaringType, getMethod));
                            }
                        });

                        if (getMethod.IsNotNull()) {
                            var getPropertyInterceptionAspectsAttrs = getMethod.GetCustomAttributes<GetPropertyInterceptionAspectAttribute>();

                            getPropertyInterceptionAspects.AddRange(getPropertyInterceptionAspectsAttrs.Select(aspectAttr => {
                                return new GetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, getMethod);
                            }));
                        }
                    });

                    aspectsCollection = new AspectDefinitionCollection(getPropertyInterceptionAspects);
                    tuples.Add(Tuple.Create(target, aspectsCollection));
                }
            });
        }

        private void CollectSetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties, ICollection<Tuple<MemberInfo, IAspectDefinitionCollection>> tuples) {
            properties.ForEach(property => {
                var setMethodTarget = property.ContractMember.GetSetMethod();

                if (setMethodTarget.IsNotNull()) {
                    MemberInfo target = property.Target.GetSetMethod();
                    IAspectDefinitionCollection aspectsCollection = null;
                    var setPropertyInterceptionAspects = new List<IAspectDefinition>();

                    property.Members.ForEach(member => {
                        var setMethod = member.GetSetMethod();
                        var propertyInterceptionAspectsAttrs = member.GetCustomAttributes<PropertyInterceptionAspectAttribute>();

                        propertyInterceptionAspectsAttrs.ForEach(aspect => {
                            if (setMethod.IsNotNull()) {
                                var setPropertyAspect = new SetPropertyInterceptionAspectAttribute(aspect.AspectType) {
                                    AspectPriority = aspect.AspectPriority,
                                    LifetimeStrategy = aspect.LifetimeStrategy
                                };

                                setPropertyInterceptionAspects.Add(new SetPropertyInterceptionAspectDefinition(setPropertyAspect, aspectDeclaringType, setMethod));
                            }
                        });

                        if (setMethod.IsNotNull()) {
                            var setPropertyInterceptionAspectsAttrs = setMethod.GetCustomAttributes<SetPropertyInterceptionAspectAttribute>();

                            setPropertyInterceptionAspects.AddRange(setPropertyInterceptionAspectsAttrs.Select(aspectAttr => {
                                return new SetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, setMethod);
                            }));
                        }
                    });

                    aspectsCollection = new AspectDefinitionCollection(setPropertyInterceptionAspects);
                    tuples.Add(Tuple.Create(target, aspectsCollection));
                }
            });
        }
    }
}
