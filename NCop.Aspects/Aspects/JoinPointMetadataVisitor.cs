using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    public class JoinPointMetadataVisitor
    {
        public AspectDefinition Visit( FieldJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }

        public AspectDefinition Visit(EventJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }

        public AspectDefinition Visit(MethodJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            return new MethodAspectDefinition(aspectProvider, joinPoint);
        }

        public AspectDefinition Visit(PropertyJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }
    }
}
