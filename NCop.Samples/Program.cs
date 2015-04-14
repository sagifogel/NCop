using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Threading.Tasks;
using System.Web;

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

    [PerHttpRequestComposite]
    [Mixins(typeof(GenericCovariantDeveloper<CSharpLanguage>))]
    public interface ICSharpDeveloper : ICovariantDeveloper<CSharpLanguage>
    {
    }

    class Program
    {
        static void Main(string[] args) {
            CompositeContainer container = null;
            ICSharpDeveloper developer = null;

            SetHttpContext();
            container = new CompositeContainer();
            container.Configure();
            developer = container.Resolve<ICSharpDeveloper>();
            Console.WriteLine(developer == container.Resolve<ICSharpDeveloper>());
            SetHttpContext();
            Console.WriteLine(developer == container.Resolve<ICSharpDeveloper>());
        }

        private static void SetHttpContext() {
            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
        }
    }
}