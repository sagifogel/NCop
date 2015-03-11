using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.PropertyAspect.Subjects
{
    public interface IPropertyAspectSubjects
    {
        List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }
        //List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty { get; }
        //List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty { set; }
        //List<AspectJoinPoints> SetPropertyInterceptionAspectOnFullProperty { get; set; }
        //List<AspectJoinPoints> GetPropertyInterceptionAspectOnFullProperty { get; set; }
        //List<AspectJoinPoints> SetPropertyInterceptionAspectOnPartialSetProperty { set; }
        //List<AspectJoinPoints> GetPropertyInterceptionAspectOnPartialGetProperty { get; }
        //List<AspectJoinPoints> MultipleSetPropertiesInterceptionAspectsOnSetProperty { set; }
        //List<AspectJoinPoints> MultipleGetPropertiesInterceptionAspectsOnGetProperty { get; }
        //List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty { get; }
        //List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty { set; }
        //List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty { get; set; }
        //List<AspectJoinPoints> GetAndSetPropertyInterceptionAspectOnFullProperty { get; set; }
        //List<AspectJoinPoints> GetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect { get; }
        //List<AspectJoinPoints> SetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect { set; }
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

        public List<AspectJoinPoints> SetPropertyInterceptionAspectOnFullProperty { get; set; }

        public List<AspectJoinPoints> GetPropertyInterceptionAspectOnFullProperty { get; set; }

        public List<AspectJoinPoints> SetPropertyInterceptionAspectOnPartialSetProperty {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }

        public List<AspectJoinPoints> GetPropertyInterceptionAspectOnPartialGetProperty {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }

        public List<AspectJoinPoints> MultipleSetPropertiesInterceptionAspectsOnSetProperty {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }

        public List<AspectJoinPoints> MultipleGetPropertiesInterceptionAspectsOnGetProperty {
            get {
                return PropertyInterceptionAspects.PropertyInterceptionAspectsList;
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

        public List<AspectJoinPoints> GetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect {
            get {
                return PropertyInterceptionAspects.PropertyInterceptionAspectsList;
            }
        }

        public List<AspectJoinPoints> SetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect {
            set {
                PropertyInterceptionAspects.PropertyInterceptionAspectsList = value;
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IPropertyAspectSubjectsComposite : IPropertyAspectSubjects
    {
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }

        //[PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        //new List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty { get; }
        //new List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty { set; }
        //new List<AspectJoinPoints> SetPropertyInterceptionAspectOnFullProperty { get; set; }
        //new List<AspectJoinPoints> GetPropertyInterceptionAspectOnFullProperty { get; set; }
        //new List<AspectJoinPoints> SetPropertyInterceptionAspectOnPartialSetProperty { set; }
        //new List<AspectJoinPoints> GetPropertyInterceptionAspectOnPartialGetProperty { get; }
        //new List<AspectJoinPoints> MultipleSetPropertiesInterceptionAspectsOnSetProperty { set; }
        //new List<AspectJoinPoints> MultipleGetPropertiesInterceptionAspectsOnGetProperty { get; }
        //new List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty { get; }
        //new List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty { set; }
        //new List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty { get; set; }
        //new List<AspectJoinPoints> GetAndSetPropertyInterceptionAspectOnFullProperty { get; set; }
        //new List<AspectJoinPoints> GetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect { get; }
        //new List<AspectJoinPoints> SetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect { set; }
    }

    public class FullPropertyInterceptionAspect : PropertyInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnGetValue(PropertyInterceptionArgs<List<AspectJoinPoints>> args) {
            var value = args.GetCurrentValue();

            value.Add(AspectJoinPoints.GetPropertyInterception);
            args.ProceedGetValue();
        }

        public override void OnSetValue(PropertyInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Value.Add(AspectJoinPoints.SetPropertyInterception);
            base.OnSetValue(args);
        }
    }
}
