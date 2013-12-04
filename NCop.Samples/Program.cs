using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Runtime.CompilerServices;

namespace NCop.Samples
{
    internal static class Aspects
    {
        internal static TraceAspect traceAspect = new TraceAspect();
        internal static TraceAspect2 traceAspect2 = new TraceAspect2();
        internal static TraceAspect2 traceAspect3 = new TraceAspect2();

        static Aspects() {
            traceAspect = new TraceAspect();
            traceAspect2 = new TraceAspect2();
            traceAspect3 = new TraceAspect2();
        }
    }

    public class FunctionBinding : IFunctionBinding<Test, string, bool>
    {
        public bool Invoke(ref Test instance, string arg1) {
            var args = new FunctionExecutionArgsImpl<Test, string, bool>(instance, arg1);

            Aspects.traceAspect2.OnEntry(args);

            try {
                args.ReturnValue = ((Test)instance).SayHello(arg1);
                Aspects.traceAspect2.OnSuccess(args);
            }
            catch (Exception) {
                Aspects.traceAspect2.OnException(args);
                throw;
            }
            finally {
                Aspects.traceAspect2.OnExit(args);
            }

            return args.ReturnValue;
        }
    }

    public class Test
    {
        public bool SayHello(string name) {
            var bindings = new FunctionBinding();
            var arguments = new FunctionInterceptionArgsImpl<Test, string, bool>(this, bindings, name);

            return true;//Aspects.traceAspect.OnInvoke(arguments);
        }

        internal bool __SayHello__(string name) {
            Console.WriteLine("Hello", name);

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();
            
			var person = container.TryResolve<IPersonComposite>();
            person.Code("CSharp");
        }
    }

    public class GenericCovariantDeveloper<T> : IDeveloper<T>
        where T : ILanguage, new()
    {
        private T langugae = new T();

        public bool Code(string code) {
            Console.WriteLine(code);

            return false;
        }
    }

    public class TraceAspect : FunctionInterceptionAspect<string, bool>
    {
        public override bool OnInvoke(FunctionInterceptionArgs<string, bool> args) {
            Console.WriteLine("TraceAspect.OnInvoke");
            args.Proceed();

            return args.ReturnValue;
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnFunctionBoundaryAspect<string, bool>
    {
        public override void OnEntry(FunctionExecutionArgs<string, bool> args) {
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<string, bool> args) {
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<string, bool> args) {
            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<string, bool> args) {
            base.OnExit(args);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 2)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 3)]
        //[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 2)]
        new bool Code(string code);
    }

    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
    {
        public override bool Code(string code) {
            return base.Code(code);
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        ILanguage language = new TLanguage();

        public virtual bool Code(string code) {
            Console.WriteLine("I am coding in " + language.Description.ToString());
            return false;
        }
    }

    public interface ILanguage
    {
        string Description { get; }
    }

    public class CSharpLanguage : ILanguage
    {
        public virtual string Description {
            get {
                return "C#";
            }
        }
    }

    public class JavaScriptLanguage : ILanguage
    {
        public string Description {
            get {
                return "JavaScript";
            }
        }
    }

    public class CSharpLanguage5 : CSharpLanguage
    {
        public override string Description {
            get {
                return "C# 5";
            }
        }
    }

    public interface IDeveloper<out TLanguage>
    {
        bool Code(string code);
    }

    public interface IDeveloper
    {
        void Code(string code);
    }
}