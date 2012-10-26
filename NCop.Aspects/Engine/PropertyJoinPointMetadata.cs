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
    public class PropertyJoinPointMetadata : JoinPointMetadata
    {
        public PropertyJoinPointMetadata(PropertyInfo property)
            : base(property) {
        }

        public override AspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider) {
            return visitor.Visit(this, aspectProvider);
        }
    }
}
