using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public abstract class JoinPointMetadata : IJoinPoint, IAcceptsVisitor<AspectDefinition, JoinPointMetadataVisitor, IAspectProvider>
    {
        public JoinPointMetadata(MemberInfo member) {
            TargetMember = member;
        }

        public MemberInfo TargetMember { get; private set; }

        public abstract AspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider);
    }
}
