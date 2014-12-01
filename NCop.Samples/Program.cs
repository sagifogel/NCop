using System;
using System.Diagnostics;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

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
        //string Code { get; }

        void Do();
    }

    internal static class FunctionArgsMapper
    {
        internal static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> second) {
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

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.Arg7 = first.Arg7;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TResult>(IFunctionArgs<TArg1, TArg2, TResult> first, IFunctionArgs<TArg1, TArg2, TResult> second) {
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

        public static void Map<TArg1, TArg2, TArg3>(IActionArgs<TArg1, TArg2, TArg3> first, IActionArgs<TArg1, TArg2, TArg3> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Method = second.Method;
        }

        public static void Map<TResult>(IFunctionArgs<TResult> first, IFunctionArgs<TResult> second) {
            second.ReturnValue = first.ReturnValue;
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        //[PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        //public string Code {
        //    [GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        //    get {
        //        return "C#";
        //    }
        //}

        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        public void Do() {

        }
    }

    public class PropertyBinding : IPropertyBinding<CSharpDeveloperMixin, string>
    {
        public static PropertyBinding singleton = null;

        static PropertyBinding() {
            singleton = new PropertyBinding();
        }

        public string GetValue(ref CSharpDeveloperMixin instance, IPropertyArg<string> arg)
        {
            return "";//instance.Code;
        }

        public void SetValue(ref CSharpDeveloperMixin instance, IPropertyArg<string> arg, string value) {
        }
    }

    public class Person : IPerson
    {
        private static CSharpDeveloperMixin instance = null;

        static Person() {
            instance = new CSharpDeveloperMixin();
        }

        public string Code {
            get {
                var codeMethod = instance.GetType().GetProperty("Code", typeof(string)).GetGetMethod();
                var interArgs = new PropertyInterceptionArgsImpl<CSharpDeveloperMixin, string>(instance, codeMethod, PropertyBinding.singleton);

                Aspects.stopWatchAspect.OnGetValue(interArgs);

                return interArgs.Value;
            }
        }

        public void Do() {
            throw new NotImplementedException();
        }
    }
    public class PropertyStopWatchAspect : PropertyInterceptionAspect<string>
    {
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
            //developer = new Person();
            //Console.WriteLine(developer.Code);
        }
    }
}