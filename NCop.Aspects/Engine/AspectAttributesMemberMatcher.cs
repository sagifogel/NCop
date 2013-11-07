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
        public AspectAttributesMemberMatcher(Type compositeType, IAspectMemebrsCollection aspectMembersCollection) {
            Values = aspectMembersCollection.Select(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return member.GetCustomAttributes<IAspect>()
                                 .Select(aspectAttr => new AspectDefinition(aspectAttr) as IAspectDefinition);
                });

                return Tuple.Create(aspectMembers.Target, aspects);
            });
        }
    }
}
