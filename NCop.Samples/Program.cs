using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Linq;

namespace NCop.Samples
{
    class Program
    {
        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();

            var person1 = container.TryResolve<IPersonComposite>("C#");
            var person2 = container.TryResolve<IPersonComposite>("JavaScript");

            Console.WriteLine(person1.Code());
            Console.WriteLine(person2.Code());
        }
    }

    [Named("JavaScript")]
    [Mixins(typeof(JavaScriptDeveloperMixin))]
    [TransientComposite(As = typeof(IPersonComposite))]
    public interface IJavaScriptPerson : IPersonComposite
    {
    }

    [Named("C#")]
    [Mixins(typeof(CSharpDeveloperMixin))]
    [TransientComposite(As = typeof(IPersonComposite))]
    public interface ICSharpPerson : IPersonComposite
    {
    }

    public interface IPersonComposite : IDeveloper
    {
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public string Code() {
            return "I am coding in C#";
        }
    }

    public class JavaScriptDeveloperMixin : IDeveloper
    {
        public string Code() {
            return "I am coding in JavaScript";
        }
    }

    public class Worker : IWorker
    {
        public void Work() {
            Console.WriteLine("Working");
        }
    }

    public interface IWorker
    {
        void Work();
    }

    public interface IDeveloper
    {
        string Code();
    }
}
