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
            var classifiedsAspects = new ClassifiedAspectPropertyMap(aspectMembersCollection.Properties);

            CollectGetPropertiesAspectDefinitions(aspectDeclaringType, classifiedsAspects.GetProperties, aspectDefinitionsCollection);
            CollectSetPropertiesAspectDefinitions(aspectDeclaringType, classifiedsAspects.SetProperties, aspectDefinitionsCollection);
            CollectBothAccessorsPropertiesAspectDefinitions(aspectDeclaringType, classifiedsAspects.BothAccessorsProperties, aspectDefinitionsCollection);

            return aspectDefinitionsCollection;
        }

        private IEnumerable<IAspectDefinition> CollectMethodsAspectDefinitions(MethodInfo member, Type aspectDeclaringType, MethodInfo target) {
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
            properties.ForEach(propertyMap => {
                IAspectDefinitionCollection aspectsCollection = null;
                MemberInfo target = propertyMap.Target.GetGetMethod();
                var getMethodTarget = propertyMap.ContractMember.GetGetMethod();
                var getPropertyInterceptionAspects = new List<IAspectDefinition>();

                propertyMap.Members.ForEach(property => {
                    var getMethod = property.GetGetMethod();
                    var getPropertyInterceptionAspectsAttrs = getMethod.GetCustomAttributes<GetPropertyInterceptionAspectAttribute>();

                    getPropertyInterceptionAspects.AddRange(getPropertyInterceptionAspectsAttrs.Select(aspectAttr => {
                        return new GetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, getMethod, propertyMap.ContractMember);
                    }));
                });

                aspectsCollection = new AspectDefinitionCollection(getPropertyInterceptionAspects);
                tuples.Add(Tuple.Create(target, aspectsCollection));
            });
        }

        private void CollectSetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties, ICollection<Tuple<MemberInfo, IAspectDefinitionCollection>> tuples) {
            properties.ForEach(propertyMap => {
                IAspectDefinitionCollection aspectsCollection = null;
                MemberInfo target = propertyMap.Target.GetSetMethod();
                var setMethodTarget = propertyMap.ContractMember.GetSetMethod();
                var setPropertyInterceptionAspects = new List<IAspectDefinition>();

                propertyMap.Members.ForEach(property => {
                    var setMethod = property.GetSetMethod();
                    var setPropertyInterceptionAspectsAttrs = setMethod.GetCustomAttributes<SetPropertyInterceptionAspectAttribute>();

                    setPropertyInterceptionAspects.AddRange(setPropertyInterceptionAspectsAttrs.Select(aspectAttr => {
                        return new SetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, setMethod, property);
                    }));
                });

                aspectsCollection = new AspectDefinitionCollection(setPropertyInterceptionAspects);
                tuples.Add(Tuple.Create(target, aspectsCollection));
            });
        }

        private void CollectBothAccessorsPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties, ICollection<Tuple<MemberInfo, IAspectDefinitionCollection>> tuples) {
            properties.ForEach(propertyMap => {
                var target = propertyMap.ContractMember;
                IAspectDefinitionCollection aspectsCollection = null;
                var setMethodTarget = propertyMap.ContractMember.GetSetMethod();
                var getMethodTarget = propertyMap.ContractMember.GetGetMethod();
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                propertyMap.Members.ForEach(property => {
                    var propertyInterceptionAspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>();

                    propertyInterceptionAspectsAttrs.ForEach(aspectAttribute => {
                        var getPropertyAspect = new GetPropertyInterceptionAspectAttribute(aspectAttribute.AspectType) {
                            AspectPriority = aspectAttribute.AspectPriority,
                            LifetimeStrategy = aspectAttribute.LifetimeStrategy
                        };

                        var setPropertyAspect = new SetPropertyInterceptionAspectAttribute(aspectAttribute.AspectType) {
                            AspectPriority = aspectAttribute.AspectPriority,
                            LifetimeStrategy = aspectAttribute.LifetimeStrategy
                        };

                        propertyInterceptionAspects.Add(new PropertyInterceptionAspectsDefinition(aspectAttribute, getPropertyAspect, setPropertyAspect, aspectDeclaringType, target));
                    });
                });

                aspectsCollection = new AspectDefinitionCollection(propertyInterceptionAspects);
                tuples.Add(Tuple.Create(target as MemberInfo, aspectsCollection));
            });
        }
    }
}
