using System.Collections.Generic;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Diagnostics;

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
        [PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        new List<string> Code { set; }

        //[MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionUsinInvokeAspect), AspectPriority = 1)]
        //[OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        //new void Do(string s);
    }

    public interface IDeveloper
    {
        List<string> Code { set; }
    }

    public interface IDo
    {
        void Do(string name);
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
        private List<string> code = new List<string>();

        //[PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        public List<string> Code {
            //[GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
            set { code = value; }
            //get { return code; }
        }


        //[GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]


        //[MethodInterceptionAspect(typeof(StopWatchAspect))]
        //[MethodInterceptionAspect(typeof(StopWatchAspect))]
        public void Do(string name) {
            Console.WriteLine(name);
        }
    }

    public class PropertyBinding0 : AbstractPropertyBinding<IDeveloper, List<string>>
    {
        public static PropertyBinding0 singleton = null;

        static PropertyBinding0() {
            singleton = new PropertyBinding0();
        }

        public override void SetValue(ref IDeveloper instance, IPropertyArg<List<string>> arg, List<string> value) {
            instance.Code = value;
        }

        //public override List<string> GetValue(ref IDeveloper instance, IPropertyArg<List<string>> arg) {
        //    return instance.Code;
        //}
    }

    public class PropertyBinding1 : AbstractPropertyBinding<IDeveloper, List<string>>
    {
        public static PropertyBinding1 singleton = null;

        static PropertyBinding1() {
            singleton = new PropertyBinding1();
        }

        public override void SetValue(ref IDeveloper instance, IPropertyArg<List<string>> arg, List<string> value) {
            var aspectArgs = new SetPropertyInterceptionArgsImpl<IDeveloper, List<string>>(instance, arg.Method, PropertyBinding0.singleton, value);

            try {
                Aspects.stopWatchAspect.OnSetValue(aspectArgs);
            }
            finally {
                arg.Value = aspectArgs.Value;
            }
        }

        public override List<string> GetValue(ref IDeveloper instance, IPropertyArg<List<string>> arg) {
            var aspectArgs = new GetPropertyInterceptionArgsImpl<IDeveloper, List<string>>(instance, arg.Method, PropertyBinding0.singleton);

            try {
                Aspects.stopWatchAspect.OnGetValue(aspectArgs);
            }
            finally {
                arg.Value = aspectArgs.Value;
            }

            return arg.Value;
        }
    }

    public class Person : IPerson
    {
        private readonly IDeveloper instance = null;

        public Person() {
            instance = new CSharpDeveloperMixin();
        }

        public List<string> Code {
            get {
                var codeMethod = instance.GetType().GetProperty("Code", typeof(List<string>)).GetGetMethod();
                var interArgs = new GetPropertyInterceptionArgsImpl<IDeveloper, List<string>>(instance, codeMethod, PropertyBinding0.singleton);
                Aspects.stopWatchAspect.OnGetValue(interArgs);

                return interArgs.Value;
            }
            set {
                var codeMethod = instance.GetType().GetProperty("Code", typeof(List<string>)).GetSetMethod();
                var interArgs = new SetPropertyInterceptionArgsImpl<IDeveloper, List<string>>(instance, codeMethod, PropertyBinding0.singleton, value);
                Aspects.stopWatchAspect.OnSetValue(interArgs);
            }
        }

        public void Do(string name) {
            throw new NotImplementedException();
        }
    }

    public class PropertyStopWatchAspect : PropertyInterceptionAspect<List<string>>
    {
        public PropertyStopWatchAspect() {

        }

        public override void OnGetValue(PropertyInterceptionArgs<List<string>> args) {
            args.ProceedGetValue();
        }

        public override void OnSetValue(PropertyInterceptionArgs<List<string>> args) {
            args.ProceedSetValue();
        }
    }

    public class StopWatchAspect : FunctionInterceptionAspect<string>
    {
        private readonly Stopwatch stopWatch = null;

        public StopWatchAspect() {
            stopWatch = new Stopwatch();
        }
        public override void OnInvoke(FunctionInterceptionArgs<string> args) {
            stopWatch.Restart();
            base.OnInvoke(args);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
        }
    }

    public class ActionWith1ArgumentInterceptionUsinInvokeAspect : ActionInterceptionAspect<string>
    {
        public override void OnInvoke(ActionInterceptionArgs<string> args) {
            args.Proceed();
        }
    }

    public class ActionWith1ArgumentOnMethodBoundaryAspect : OnActionBoundaryAspect<string>
    {
        public override void OnEntry(ActionExecutionArgs<string> args) {
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<string> args) {
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<string> args) {
            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<string> args) {
            base.OnExit(args);
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var s = PropertyBinding0.singleton;
            var p = new Person();
            List<string> code = null;//p.Code;
            IPerson developer = null;
            var container = new CompositeContainer();
            container.Configure();
            developer = container.Resolve<IPerson>();
            developer.Code = new List<string>() { " Sagi " };
        }
    }
}