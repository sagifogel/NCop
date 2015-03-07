using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
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

    public class Mixin : IPropertyAspectSubjects
    {
        public List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public List<AspectJoinPoints> PropertyInterceptionAspectOnPartialGetProperty {
            get { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> PropertyInterceptionAspectOnPartialSetProperty {
            set { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> SetPropertyInterceptionAspectOnFullProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public List<AspectJoinPoints> GetPropertyInterceptionAspectOnFullProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public List<AspectJoinPoints> SetPropertyInterceptionAspectOnPartialSetProperty {
            set { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> GetPropertyInterceptionAspectOnPartialGetProperty {
            get { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> MultipleSetPropertiesInterceptionAspectsOnSetProperty {
            set { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> MultipleGetPropertiesInterceptionAspectsOnGetProperty {
            get { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialGetProperty {
            get { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectOnPartialSetProperty {
            set { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> MultiplePropertyInterceptionAspectsOnFullProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public List<AspectJoinPoints> GetAndSetPropertyInterceptionAspectOnFullProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public List<AspectJoinPoints> GetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect {
            get { throw new NotImplementedException(); }
        }

        public List<AspectJoinPoints> SetPropertyInterceptionAspectWrappedWithPropertyInterceptionAspect {
            set { throw new NotImplementedException(); }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IPropertyAspectSubjectsComposite : IPropertyAspectSubjects
    {
        [PropertyInterceptionAspect(typeof(FullPropertyInterceptionAspect))]
        new List<AspectJoinPoints> PropertyInterceptionAspectOnFullProperty { get; set; }
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
            args.Value.Add(AspectJoinPoints.PropertyInterception);
            base.OnGetValue(args);
        }

        public override void OnSetValue(PropertyInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Value.Add(AspectJoinPoints.PropertyInterception);
            base.OnSetValue(args);
        }
    }
}
