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
            Values = aspectMembersCollection.Select(aspectMembers => {
                var target = aspectMembers.Target;
                var aspects = aspectMembers.Members.SelectMany(member => {
                    if (member.MemberType == MemberTypes.Method) {
                        return CollectMethodsAspectDefinitions(member as MethodInfo, aspectDeclaringType, target);
                    }

                    return CollectPropertiesAspectDefinitions(member as PropertyInfo, aspectDeclaringType, target);
                });

                var aspectsCollection = new AspectDefinitionCollection(aspects) as IAspectDefinitionCollection;

                return Tuple.Create(aspectMembers.Target, aspectsCollection);
            });
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

        private IEnumerable<IAspectDefinition> CollectPropertiesAspectDefinitions(PropertyInfo member, Type aspectDeclaringType, MemberInfo target) {
            var propertyInterceptionAspects = member.GetCustomAttributes<PropertyInterceptionAspectAttribute>();
            IEnumerable<IAspectDefinition> aspectDefinitions = propertyInterceptionAspects.Select(aspect => {
                return new PropertyInterceptionAspectDefinition(aspect, aspectDeclaringType, target);
            });

            if (aspectDefinitions.IsNullOrEmpty()) {
                var getMethod = member.GetGetMethod();
                var setMethod = member.GetSetMethod();

                if (getMethod.IsNotNull()) {
                    var getPropertyInterceptionAspects = getMethod.GetCustomAttributes<GetPropertyInterceptionAspectAttribute>();

                    aspectDefinitions = getPropertyInterceptionAspects.Select(aspect => {
                        return new GetPropertyInterceptionAspectDefinition(aspect, aspectDeclaringType, getMethod);
                    });
                }

                if (setMethod.IsNotNull()) {
                    var setPropertyInterceptionAspects = setMethod.GetCustomAttributes<SetPropertyInterceptionAspectAttribute>();

                    aspectDefinitions = aspectDefinitions.Concat(setPropertyInterceptionAspects.Select(aspect => {
                        return new SetPropertyInterceptionAspectDefinition(aspect, aspectDeclaringType, setMethod);
                    }));
                }
            }

            return aspectDefinitions;
        }
    }
}
