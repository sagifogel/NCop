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
    public class AspectAttributesMemberMatcher : Tuples<MemberInfo, IEnumerable<IAspectDefinition>>
    {
        public AspectAttributesMemberMatcher(Type aspectDeclaringType, IAspectMemebrsCollection aspectMembersCollection) {
            Values = aspectMembersCollection.Select(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    var onMethodBoundaryAspects = member.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
                    var methodInterceptionAspects = member.GetCustomAttributes<MethodInterceptionAspectAttribute>();
                    
					var onMethodBoundaryAspectDefinitions = onMethodBoundaryAspects.Select(aspect => {
                        return new OnMethodBoundaryAspectDefinition(aspect);
                    });

                    var methodInterceptionAspectDefinitions = methodInterceptionAspects.Select(aspect => {
                        return new MethodInterceptionAspectDefinition(aspect);
                    });

                    return methodInterceptionAspectDefinitions.Cast<IAspectDefinition>()
                                                              .Concat(onMethodBoundaryAspectDefinitions);
                });

                return Tuple.Create(aspectMembers.Target, aspects);
            });
        }
    }
}
