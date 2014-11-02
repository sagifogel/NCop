using System;
using System.Diagnostics;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples
{
	[TransientComposite]
	[Mixins(typeof(CSharpDeveloperMixin))]
	public interface IPerson : IDeveloper
	{
	}

	public interface IDeveloper
	{
		[PropertyInterceptionAspect(typeof(StopWatchAspect))]
		string Code { get; }
	}

	public class CSharpDeveloperMixin : IDeveloper
	{
		public string Code {
			get { return "C#"; }
		}

		[MethodInterceptionAspect(typeof(StopWatchAspect))]
		public void Do() {

		}
	}

	public class StopWatchAspect : ActionInterceptionAspect
	{
		private readonly Stopwatch stopWatch = null;

		public StopWatchAspect() {
			stopWatch = new Stopwatch();
		}

		public override void OnInvoke(ActionInterceptionArgs args) {
			stopWatch.Restart();
			base.OnInvoke(args);
			stopWatch.Stop();
			Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
		}
	}

	class Program
	{
		static void Main(string[] args) {
			IPerson developer = null;
			var container = new CompositeContainer();

			container.Configure();
			developer = container.Resolve<IPerson>();
			Console.WriteLine(developer.Code);
		}
	}
}