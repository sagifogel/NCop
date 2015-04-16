using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Mixins.Framework;
using StructureMap;

namespace NCop.Samples
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        event Action<string> Ev;
        void RaiseEvent();
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Action<string> Ev;

        public void RaiseEvent() {
            if (Ev != null) {
                Ev("C# coding");
            }
        }
    }

    public class DeveloperComposite : IDeveloper
    {
        CSharpDeveloperMixin mixin = new CSharpDeveloperMixin();

        public event Action<string> Ev {
            add {
                mixin.Ev += value;
            }
            remove {
                mixin.Ev -= value;
            }
        }

        public void RaiseEvent() {
            mixin.RaiseEvent();
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IDeveloper person = new DeveloperComposite();
            var container = new CompositeContainer();

            container.Configure();
            person = container.Resolve<IDeveloper>();

            //person.Ev += (value) => {
            //    Console.WriteLine(value);
            //};

            person.RaiseEvent();
        }
    }
}