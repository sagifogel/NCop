using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NCop.Samples
{
    class Program
    {
        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();
            var person = container.TryResolve<IPersonComposite>();

            Console.WriteLine(person.Code(new CSharpLanguage5()));
        }
    }


    public class GenericCovariantDeveloper<T> : IDeveloper<T>
        where T : ILanguage, new()
    {
        private T langugae = new T();

        public string Code() {
            return langugae.Description;
        }
    }

    public class GenericContraVariantDeveloper : IContraVariantDeveloper<CSharpLanguage5>
    {
        public string Code(CSharpLanguage5 language) {
            return language.Description;
        }
    }

    [TransientComposite]
    [Mixins(typeof(GenericContraVariantDeveloper))]
    public interface IPersonComposite : IContraVariantDeveloper<ILanguage>
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

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        ILanguage language = new TLanguage();

        public virtual string Code() {
            return language.Description.ToString();
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
        string Code();
    }

    public interface IContraVariantDeveloper<in TLanguage>
    {
        string Code(TLanguage lanuage);
    }

    public interface IDeveloper
    {
        string Code();
    }

    public interface IDeveloper2<in TLanguage>
    {
        string Code(TLanguage language);
    }
}
