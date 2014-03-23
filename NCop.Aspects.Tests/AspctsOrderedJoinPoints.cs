using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    public class OnMethodBoundaryAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public OnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnException);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class InterceptionAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public InterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }
}
