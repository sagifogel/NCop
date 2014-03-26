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

    public class MultipleOnMethodBoundaryAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public MultipleOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class MultipleInterceptionAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public MultipleInterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : List<AspectJoinPoints>
    {
        public AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithInterceptionAspect : List<AspectJoinPoints>
    {
        public AllAspectOrderedJoinPointsStartingWithInterceptionAspect() {
            Add(AspectJoinPoints.OnInvoke);
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

    public class AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect : List<AspectJoinPoints>
    {
        public AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : List<AspectJoinPoints>
    {
        public AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
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
