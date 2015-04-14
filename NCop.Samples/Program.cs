using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Threading.Tasks;

namespace NCop.Samples
{
    public class GenericCovariantDeveloper<T> : ICovariantDeveloper<T> where T : CILLanguage, new()
    {
        private readonly T langugae = new T();

        public GenericCovariantDeveloper() {
            Console.WriteLine("GenericCovariantDeveloper");
        }

        public string Code() {
            return langugae.Name;
        }
    }

    public interface ICovariantDeveloper<out T>
    {
        string Code();
    }

    public abstract class CILLanguage
    {
        public abstract string Name { get; }
    }

    public class CSharpLanguage : CILLanguage
    {
        public override string Name {
            get {
                return "C# coding";
            }
        }
    }

    [PerThreadComposite]
    [Mixins(typeof(GenericCovariantDeveloper<CSharpLanguage>))]
    public interface ICSharpDeveloper : ICovariantDeveloper<CSharpLanguage>
    {
    }

    class Program
    {
        static void Main(string[] args) {
            Task task1 = null;
            Task task2 = null;
            ICSharpDeveloper developer1 = null;
            ICSharpDeveloper developer2 = null;
            var container = new CompositeContainer();

            container.Configure();
            task1 = Task.Factory.StartNew(() =>
            developer1 = container.Resolve<ICSharpDeveloper>());
            task2 = Task.Factory.StartNew(() => developer2 = container.Resolve<ICSharpDeveloper>());

            Task.WhenAll(task1, task2).Wait();
            Console.WriteLine(developer1.Equals(developer2));
            Console.WriteLine(container.Resolve<ICSharpDeveloper>() == container.Resolve<ICSharpDeveloper>());
        }
    }
}