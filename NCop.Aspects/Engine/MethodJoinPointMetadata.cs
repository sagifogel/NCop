using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public class MethodJoinPointMetadata : JoinPointMetadata
    {
        public MethodJoinPointMetadata(MethodInfo method)
            : base(method) {
        }

        public override IAspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider) {
            return visitor.Visit(this, aspectProvider);
        }
    }
}
