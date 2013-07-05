using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class GenericCSharpDeveloperImpl : IDeveloper<CSharpLanguage>
    {
        public string Code() {
            return new CSharpLanguage().Name;
        }
    }


    public class GenericDeveloper<T> : IDeveloper<T>
        where T : MSILLanguage, new()
    {
        private MSILLanguage langugae = new T();

        public string Code() {
            return langugae.Name;
        }
    }

    public class GenericCovariantDeveloper<T> : ICovariantDeveloper<T>
        where T : MSILLanguage, new()
    {
        private T langugae = new T();

        public string Code() {
            return langugae.Name;
        }
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

    public interface IDeveloper
    {
        string Code();
    }

    public class CSharpLanguage : MSILLanguage
    {
        public override string Name {
            get {
                return "C#";
            }
        }
    }

    public class VBNet : MSILLanguage
    {
        public override string Name {
            get {
                return "VB.NET";
            }
        }
    }

    public abstract class MSILLanguage
    {
        public abstract string Name { get; }
    }
}
