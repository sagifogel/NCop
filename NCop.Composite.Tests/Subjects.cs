using NCop.Composite.Framework;

namespace NCop.Composite.Tests
{
    public interface IPersonComposite : IDeveloper
    {
    }

    public interface ICovariantDeveloper<out T>
    {
        string Code();
    }

    public interface IDeveloper<T>
    {
        string Code();
    }

    [Named("GenericCSharpDeveloperImpl")]
    public class GenericCSharpDeveloperImpl : IDeveloper<CSharpLanguage>
    {
        public string Code() {
            return new CSharpLanguage().Name;
        }
    }

    public class GenericDeveloper<T> : IDeveloper<T> where T : CILLanguage, new()
    {
        private CILLanguage langugae = new T();

        public string Code() {
            return langugae.Name;
        }
    }

    public class GenericCovariantDeveloper<T> : ICovariantDeveloper<T> where T : CILLanguage, new()
    {
        private readonly T langugae = new T();

        public string Code() {
            return langugae.Name;
        }
    }

    [Named("CSharpDeveloperMixin")]
    public class CSharpDeveloperMixin : IDeveloper
    {
        public string Code() {
            return "I am coding in C#";
        }
    }

    [Named("JavaScriptDeveloperMixin")]
    public class JavaScriptDeveloperMixin : IDeveloper
    {
        public string Code() {
            return "I am coding in JavaScript";
        }
    }

    public interface IDeveloper
    {
        string Code();
    }

    public class CSharpLanguage : CILLanguage
    {
        public override string Name {
            get {
                return "C#";
            }
        }
    }

    public class VBNet : CILLanguage
    {
        public override string Name {
            get {
                return "VB.NET";
            }
        }
    }

    public abstract class CILLanguage
    {
        public abstract string Name { get; }
    }
}
