using NCop.Aspects.Framework;
using NCop.Composite.Engine;
using NCop.Composite.Framework;
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

        static void Main(string[] args) {
            //NCop.
        }
    }

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

    [Mixins(new Type[] { typeof(DrummerMixin) })]
    [TransientComposite]
    [Aspects(new Type[] { typeof(IDrummerAspectFilter) })]
    public interface IPersonComposite : IEngineer, IDrummer
    {
    }

    public class PersonComposite : IPersonComposite, IEngineer, IDrummer
    {
        private IEngineer IEngineer;
        private IDrummer IDrummer;

        public PersonComposite() {
            this.IEngineer = (IEngineer)null;
            this.IDrummer = (IDrummer)null;
        }

        public void DoWork() {
            this.IEngineer.DoWork();
        }

        public void Play() {
            this.IDrummer.Play();
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
