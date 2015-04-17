using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Mixins.Framework;
using StructureMap;
using NCop.Aspects.Framework;
using System.Diagnostics;

namespace NCop.Samples
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(ActionEventInterceptionAspect))]
        event Action<string> Ev;
        //void RaiseEvent(string s);
    }

    public class ActionEventInterceptionAspect : ActionEventInterceptionAspect<string>
    {
        public override void OnAddHandler(ActionEventInterceptionArgs<string> args) {
            base.OnAddHandler(args);
        }

        public override void OnInvokeHandler(ActionEventInterceptionArgs<string> args) {
            base.OnInvokeHandler(args);
        }

        public override void OnRemoveHandler(ActionEventInterceptionArgs<string> args) {
            base.OnRemoveHandler(args);
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Action<string> Ev;

        public void RaiseEvent(string s) {
            if (Ev != null) {
                Ev("C# coding");
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IDeveloper person;
            var container = new CompositeContainer();

            container.Configure();
            person = container.Resolve<IDeveloper>();

            //person.Ev += (value) => {
            //    Console.WriteLine(value);
            //};

            //person.RaiseEvent("");
        }
    }
}