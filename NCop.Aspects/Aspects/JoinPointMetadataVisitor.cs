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
        public IAspectDefinition Visit(FieldJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }

        public IAspectDefinition Visit(EventJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }

        public IAspectDefinition Visit(MethodJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            return new MethodAspectDefinition(aspectProvider, joinPoint);
        }

        public IAspectDefinition Visit(PropertyJoinPointMetadata joinPoint, IAspectProvider aspectProvider) {
            throw new NotImplementedException();
        }
    }
}
