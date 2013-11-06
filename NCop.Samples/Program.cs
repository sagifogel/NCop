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
			person.Code("CSharp");
		}
	}

	public class GenericCovariantDeveloper<T> : IDeveloper<T>
		where T : ILanguage, new()
	{
		private T langugae = new T();

		public void Code(string code) {
			 Console.WriteLine(code);
		}
	}
       
    public class TraceAspect : OnActionBoundaryAspect<string>
	{
		public override void OnEntry(ActionExecutionArgs<string> args) {
			base.OnEntry(args);
		}
	}

    [PerThreadAspect]
    public class TraceAspect2 : OnActionBoundaryAspect<string>
    {
        public override void OnEntry(ActionExecutionArgs<string> args) {
            base.OnEntry(args);
        }
    }

	[TransientComposite]
	[Mixins(typeof(CSharpDeveloperMixin))]
	public interface IPersonComposite : IDeveloper<ILanguage>
	{
	}

	public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
	{	
		[OnMethodBoundaryAspect(typeof(TraceAspect))]
        [OnMethodBoundaryAspect(typeof(TraceAspect2))]
		public override void Code(string code)
		{
			base.Code(code);
		}
	}

	public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
	{
		
	}

	public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
		where TLanguage : ILanguage, new()
	{
		ILanguage language = new TLanguage();

		public virtual void Code(string code) {
			Console.WriteLine("I am coding in " + language.Description.ToString());
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
		void Code(string code);
	}

	public interface IDeveloper
	{
		void Code(string code);
	}
}