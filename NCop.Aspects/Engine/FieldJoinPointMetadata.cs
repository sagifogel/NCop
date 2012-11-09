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
    public class FieldJoinPointMetadata : JoinPointMetadata
    {
        public FieldJoinPointMetadata(FieldInfo field)
            : base(field) {
        }

        public override IAspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider) {
            return visitor.Visit(this, aspectProvider);
        }
    }
}