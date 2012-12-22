using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.JoinPoints
{
    public abstract class JoinPointMetadata : IJoinPoint, IAcceptsVisitor<IAspectDefinition, JoinPointMetadataVisitor, IAspectProvider>
    {
        public JoinPointMetadata(MemberInfo member) {
            TargetMember = member;
        }

        public MemberInfo TargetMember { get; private set; }

        public abstract IAspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider);
    }
}
