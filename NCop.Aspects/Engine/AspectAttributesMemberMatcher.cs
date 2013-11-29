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
                var aspects = aspectMembers.Members.SelectMany(member => {
                    var onMethodBoundaryAspects = member.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
                    var methodInterceptionAspects = member.GetCustomAttributes<MethodInterceptionAspectAttribute>();

                    var onMethodBoundaryAspectDefinitions = onMethodBoundaryAspects.Select(aspect => {
                        return new OnMethodBoundaryAspectDefinition(aspect, aspectDeclaringType);
                    });

                    var methodInterceptionAspectDefinitions = methodInterceptionAspects.Select(aspect => {
                        return new MethodInterceptionAspectDefinition(aspect, aspectDeclaringType);
                    });

                    return methodInterceptionAspectDefinitions.Cast<IAspectDefinition>()
                                                              .Concat(onMethodBoundaryAspectDefinitions);
                });

                var aspectsCollection = new AspectDefinitionCollection(aspects) as IAspectDefinitionCollection;

                return Tuple.Create(aspectMembers.Target, aspectsCollection);
            });
        }
    }
}
