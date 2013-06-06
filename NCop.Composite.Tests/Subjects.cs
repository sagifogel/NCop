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
}
