using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.PropertyAspect.Subjects
{
    public interface IPropertyAspectSubjects
    {
        List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }
        List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty { get; }
        List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty { set; }
        List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty { get; set; }
        List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty { get; }
        List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty { set; }
    }

    public static class PropertyInterceptionAspects
    {
        public static List<AspectJoinPoints> PropertyInterceptionAspectsList = new List<AspectJoinPoints>();
    }

    public class Mixin : IPropertyAspectSubjects
    {
        public List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }

        public List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty {
            get {
                return PropertyInterceptionAspects.PropertyInterceptionAspectsList;
            }
        }

        public List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty {
            get {
                return PropertyInterceptionAspects.PropertyInterceptionAspectsList;
            }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty { get; set; }

        public List<AspectJoinPoints> GetAndSetPropertyInterceptionAspectOnFullProperty { get; set; }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IPropertyAspectSubjectsComposite : IPropertyAspectSubjects
    {
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty { get; }

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty { set; }

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty { get; set; }

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty { get; }

        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty { set; }
    }

    public class FullPropertyInterceptionAspect : PropertyInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnGetValue(PropertyInterceptionArgs<List<AspectJoinPoints>> args) {
            args.ProceedGetValue();
            args.Value.Add(AspectJoinPoints.GetPropertyInterception);
        }

        public override void OnSetValue(PropertyInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Value.Add(AspectJoinPoints.SetPropertyInterception);
            args.ProceedSetValue();
        }
    }
}
