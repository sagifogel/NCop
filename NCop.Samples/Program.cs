using System;
using System.Diagnostics;
using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
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
        //[PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        new string Code { get; set; }
    }

    public interface IDeveloper
    {
        //[PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        string Code { get; set; }
    }

    public interface IDo
    {
        void Do();
    }

    public class CSharpDeveloperMixin : IDeveloper, IDo
    {
        private string code = "C#";

        [PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        public string Code {
            get { return code; }
            set { code = value; }
        }

        //[GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]


        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        //[MethodInterceptionAspect(typeof(StopWatchAspect))]
        public void Do() {

        }
    }

    public class PropertyBinding : AbstractPropertyBinding<IDeveloper, string>
    {
        public static PropertyBinding singleton = null;

        static PropertyBinding() {
            singleton = new PropertyBinding();
        }

        public override string GetValue(ref IDeveloper instance, IPropertyArg<string> arg) {
            return instance.Code;
        }

        public override void SetValue(ref IDeveloper instance, IPropertyArg<string> arg, string value) {
            throw new NotSupportedException();
        }
    }

    public class Person : IPerson
    {
        private readonly IDeveloper instance = null;

        public Person() {
            instance = new CSharpDeveloperMixin();
        }

        public string Code {
            get {
                var codeMethod = instance.GetType().GetProperty("Code", typeof(string)).GetGetMethod();
                var interArgs = new GetPropertyInterceptionArgsImpl<IDeveloper, string>(instance, codeMethod, PropertyBinding.singleton);
                Aspects.stopWatchAspect.OnGetValue(interArgs);

                return interArgs.Value;
            }
            set { }
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
            //var code = new Person().Code;
            IPerson developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IPerson>();
            Console.WriteLine(developer.Code);
        }
    }
}