using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

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

	public class GenericCovariantDeveloper<T> : IDeveloper<T>
		where T : ILanguage, new()
	{
		private T langugae = new T();

		public string Code() {
			return langugae.Description;
		}
	}

	public class TraceAspect : OnFunctionBoundaryAspectImpl<string>
	{
		public override void OnEntry(FunctionExecutionArgs<string> args) {
		}
	}

	[TransientComposite]
	[Mixins(typeof(CSharpDeveloperMixin))]
	public interface IPersonComposite : IDeveloper<ILanguage>
	{
	}

	public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
	{
		[OnMethodBoundaryAspectAttribute(typeof(TraceAspect))]
		public override string Code() {
			return base.Code();
		}
	}

	public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
	{
		
	}

	public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
		where TLanguage : ILanguage, new()
	{
		ILanguage language = new TLanguage();

		public virtual string Code() {
			return "I am coding in " + language.Description.ToString();
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

	public interface IDeveloper
	{
		string Code();
	}
}