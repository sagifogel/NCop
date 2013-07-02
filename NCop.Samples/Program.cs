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
            var person = container.TryResolve<IPersonComposite>();

            Console.WriteLine(person.Code());
        }
    }

    [Mixins(typeof(CSharpDeveloperMixin))]
    [TransientComposite(typeof(IPersonComposite))]
    public interface IPersonComposite : IDeveloper<CSharpLanguage>
    {
    }

    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
    {
        public override string Code() {
            return "I am coding in " + base.Code();
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {
        public override string Code() {
            return "I am coding in " + base.Code();
        }
    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage> where TLanguage : ILanguage, new()
    {
        protected ILanguage Language = new TLanguage();

        public virtual string Code() {
            return Language.Description.ToString();
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

    public interface IDeveloper<out TLanguage> where TLanguage : ILanguage
    {
        string Code();
    }
}
