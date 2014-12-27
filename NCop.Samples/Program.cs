using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using NCop.Weaving;
using NCop.Weaving.Extensions;

namespace NCop.Samples
{
    internal static class Aspects
    {
        public static CSharpDeveloperMixin mixin = null;
        public static PropertyStopWatchAspect stopWatchAspect = null;

        static Aspects() {
            stopWatchAspect = new PropertyStopWatchAspect();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPerson : IDeveloper
    {
    }

    public interface IDeveloper
    {
        string Code { get; }
    }

    public interface IDo
    {
        void Do();
    }

    internal static class FunctionArgsMapper
    {
        internal static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.Arg7 = first.Arg7;
            second.Arg8 = first.Arg8;
            second.ReturnValue = first.ReturnValue;
        }

        internal static void Map<TArg>(IFunctionArgs<TArg> first, IPropertyArg<TArg> second) {
            second.Value = first.ReturnValue;
            second.Method = first.Method;
        }

        internal static void Map<TArg>(IActionArgs<TArg> first, IPropertyArg<TArg> second) {
            second.Value = first.Arg1;
        }

        internal static void Map<TArg>(IPropertyArg<TArg> first, IFunctionArgs<TArg> second) {
            second.ReturnValue = first.Value;
            second.Method = first.Method;
        }

        internal static void Map<TArg>(IPropertyArg<TArg> first, IActionArgs<TArg> second) {
            second.Arg1 = first.Value;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.Arg7 = first.Arg7;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TResult>(
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TResult> first,
            IFunctionArgs<TArg1, TArg2, TArg3, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TResult>(IFunctionArgs<TArg1, TArg2, TResult> first,
            IFunctionArgs<TArg1, TArg2, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TResult>(IFunctionArgs<TArg1, TResult> first, IFunctionArgs<TArg1, TResult> second) {
            second.Arg1 = first.Arg1;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1>(IActionArgs<TArg1> first, IActionArgs<TArg1> second) {
            second.Arg1 = first.Arg1;
            second.Method = second.Method;
        }

        public static void Map<TArg1, TArg2, TArg3>(IActionArgs<TArg1, TArg2, TArg3> first,
            IActionArgs<TArg1, TArg2, TArg3> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Method = second.Method;
        }

        public static void Map<TResult>(IFunctionArgs<TResult> first, IFunctionArgs<TResult> second) {
            second.ReturnValue = first.ReturnValue;
        }
    }

    public class CSharpDeveloperMixin : IDeveloper, IDo
    {
        private string code = "C#";

        [PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        public string Code {
            get { return code; }
        }

        //[GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]


        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        //[MethodInterceptionAspect(typeof(StopWatchAspect))]
        public void Do() {

        }
    }

    //public class PropertyBinding : AbstractPropertyBinding<IDeveloper, string>
    //{
    //    public static PropertyBinding singleton = null;

    //    static PropertyBinding() {
    //        singleton = new PropertyBinding();
    //    }

    //    public override string GetValue(ref IDeveloper instance, IPropertyArg<string> arg) {
    //        return instance.Code;
    //    }

    //    public override void SetValue(ref IDeveloper instance, IPropertyArg<string> arg, string value) {
    //        throw new NotSupportedException();
    //    }
    //}

    public class Person : IPerson
    {
        private readonly IDeveloper instance = null;

        public Person() {
            instance = new CSharpDeveloperMixin();
        }

        public string Code {
            get {
                //var codeMethod = instance.GetType().GetProperty("Code", typeof(string)).GetGetMethod();
                //var interArgs = new GetPropertyInterceptionArgsImpl<IDeveloper, string>(instance, codeMethod, PropertyBinding.singleton);
                Aspects.stopWatchAspect.OnGetValue(null);

                return "";//interArgs.Value;
            }
        }
    }

    public class PropertyStopWatchAspect : PropertyInterceptionAspect<string>
    {
        public PropertyStopWatchAspect() {

        }

        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            base.OnGetValue(args);
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            base.OnSetValue(args);
        }
    }

    public class StopWatchAspect : ActionInterceptionAspect
    {
        private readonly Stopwatch stopWatch = null;

        public StopWatchAspect() {
            stopWatch = new Stopwatch();
        }

        public override void OnInvoke(ActionInterceptionArgs args) {
            stopWatch.Restart();
            base.OnInvoke(args);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IPerson developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IPerson>();
            Console.WriteLine(developer.Code);
        }
    }
}