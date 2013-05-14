using NCop.Aspects.Framework;
using NCop.Composite.Engine;
using NCop.Composite.Framework;
using NCop.Core;
using NCop.IoC;
using NCop.IoC.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCop.Samples
{
    class Program
    {
        public interface IFoo
        {
            Baz MyProperty { get; }
        }

        public class Baz
        {
        }

        public class Foo : IFoo
        {
            public Baz MyProperty { get; set; }
        }

        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();

            var resolved = container.Resolve<IPersonComposite>();
        }
    }

    [IgnoreRegistration]
    public interface IDrummer
    {
        void Play();
    }

    public interface IDrummerAspectFilter : IAspectFilter, IDrummer
    {
        [ProfilerAspect]
        new void Play();
    }

    public class DrummerMixin : IDrummer
    {
        public IEngineer Engineer { get; set; }

        public DrummerMixin(IEngineer engineer) {
            Engineer = engineer;
        }

        public void Play() {
        }
    }

    public class EngineerMixin : IEngineer
    {
        public void DoWork() {
            throw new NotImplementedException();
        }

        public object Clone() {
            throw new NotImplementedException();
        }
    }

    public interface IEngineerAspectFilter : IAspectFilter, IEngineer
    {
        [ProfilerAspect(AspectPriority = 1)]
        new void DoWork();
    }

    [Aspects(new Type[] { typeof(IEngineerAspectFilter) })]
    [Mixins(new Type[] { typeof(EngineerMixin) })]
    public interface IEngineer
    {
        void DoWork();
    }

    [TransientComposite]
    [Mixins(new Type[] { typeof(DrummerMixin) })]
    [Aspects(new Type[] { typeof(IDrummerAspectFilter) })]
    public interface IPersonComposite : IEngineer, IDrummer
    {
    }

    public class PersonComposite : IPersonComposite, IEngineer, IDrummer
    {
        private IEngineer engineer;
        private IDrummer drummer;

        public PersonComposite(IEngineer engineer, IDrummer drummer) {
            this.engineer = engineer;
            this.drummer = drummer;
        }

        public void DoWork() {
            this.engineer.DoWork();
        }

        public void Play() {
            this.drummer.Play();
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class ProfilerAspectAttribute : OnMethodBoundaryAspectAttribute
    {
        public ProfilerAspectAttribute() {
        }

        public override void OnEntry(IMethodExecution methodExecution) {
        }

        public override void OnExit(IMethodExecution methodExecution) {
            throw new NotImplementedException();
        }

        public override void OnSuccess(IMethodExecution methodExecution) {
            throw new NotImplementedException();
        }

        public override void OnException(IMethodExecution methodExecution) {
            throw new NotImplementedException();
        }
    }
}
