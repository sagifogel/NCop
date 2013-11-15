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

namespace NCop.Samples
{
    public class FunctionBinding : IFunctionBinding<string, bool>
    {
        private Func<string, bool> factory = null;

        public FunctionBinding(Func<string, bool> factory) {
            this.factory = factory;
        }
        public bool Invoke(ref object instance, string arg1) {
            var args = new FunctionExecutionArgsImpl<string, bool>(instance, arg1);

            Program.traceAspect2.OnEntry(args);

            try {
                args.ReturnValue = factory(arg1);
                Program.traceAspect2.OnSuccess(args);
            }
            catch (Exception) {
                Program.traceAspect2.OnException(args);
                throw;
            }
            finally {
                Program.traceAspect2.OnExit(args);
            }

            return args.ReturnValue;
        }
    }

    class Program
    {
        public static TraceAspect traceAspect = new TraceAspect();
        public static TraceAspect2 traceAspect2 = new TraceAspect2();

        static void Main(string[] args) {
            //var container = new CompositeContainer();
            //container.Configure();
            Code("sdasdadasd");
            //var person = container.TryResolve<IPersonComposite>();
            //person.Code("CSharp");
        }

        private static void Code(string code) {
            var instance = new CSharpDeveloperMixin();
            var bindings = new FunctionBinding(instance.Code);
            var arguments = new FunctionInterceptionArgsImpl<string, bool>(instance, bindings, code);

            traceAspect.OnInvoke(arguments);
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
            return base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnFunctionBoundaryAspect<string, bool>
    {
        public override void OnEntry(FunctionExecutionArgs<string, bool> args) {
            base.OnEntry(args);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        [OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
        new void Code(string code);
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