using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.JoinPoints
{
    public class EventJoinPointMetadata : JoinPointMetadata
    {
        public EventJoinPointMetadata(EventInfo @event)
            : base(@event) {
        }

        public override IAspectDefinition Accept(JoinPointMetadataVisitor visitor, IAspectProvider aspectProvider) {
            return visitor.Visit(this, aspectProvider);
        }
    }
}