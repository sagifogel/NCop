using NCop.Aspects.Framework;
using NCop.Aspects.Tests.ActionWith1ArgumentAspect.Subjects;
using NCop.Aspects.Tests.PropertyAspect.Subjects;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.MethodsAndPropertiesAspect.Subjects
{
    public interface IMethodsAndPropertiesAspectSubjects
    {
        void InterceptionAspect(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);
        List<AspectJoinPoints> VanillaPropertyWithoutAnyAspects { get; set; }
        void VanillaMethodWithoutAnyAspects(List<AspectJoinPoints> joinPoints);
        List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }
    }

    public class Mixin : IMethodsAndPropertiesAspectSubjects
    {
        public List<AspectJoinPoints> VanillaPropertyWithoutAnyAspects { get; set; }

        public List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }

        private void AddInMethodJoinPoint(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void VanillaMethodWithoutAnyAspects(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IMethodsAndPropertiesSubjectsComposite : IMethodsAndPropertiesAspectSubjects
    {
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> joinPoints);

        new List<AspectJoinPoints> VanillaPropertyWithoutAnyAspects { get; set; }

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);

        new void VanillaMethodWithoutAnyAspects(List<AspectJoinPoints> joinPoints);

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }
    }
}
