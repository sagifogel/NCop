using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using NCop.IoC;

namespace NCop.Samples
{
	class Program
	{
		static void Main(string[] args) {
			var container = new CompositeContainer();

			container.Configure();
			var a = container.Resolve<IAlaaGandrey>();
		}
	}

	public class TraceAspect : OnFunctionBoundaryAspectImpl<bool>
	{
		public override void OnEntry(FunctionExecutionArgs<bool> args) {
		}
	}

	[TransientComposite]
	[Mixins(typeof(Husband), typeof(CSharpDeveloper))]
	public interface IAlaaGandrey : IHusband, IDeveloper
	{
		[OnMethodBoundryAspectAttribute(typeof(TraceAspect))]
		new bool TakeGarbage();
	}

	public interface IHusband
	{
		bool TakeGarbage();
	}

	public interface IDeveloper
	{
		string Develop();
	}

	public class CSharpDeveloper : IDeveloper
	{
		public string Develop() {
			return "CSharp";
		}
	}

	public class JavaScriptDeveloper : IDeveloper
	{
		public string Develop() {
			return "JS";
		}
	}

	public class Husband : IHusband
	{
		public bool TakeGarbage() {
			return true;
		}
	}
}