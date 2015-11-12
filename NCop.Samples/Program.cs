using NCop.Samples.MultipleAspects.Events;

namespace NCop.Samples
{
    //[TransientComposite]
    //[Mixins(typeof(CSharpDeveloperMixin))]
    //public interface IDeveloper
    //{
    //    [MethodInterceptionAspect(typeof(InterceptionAspectImpl2))]
    //    [MethodInterceptionAspect(typeof(AnotherInterceptionAspectImpl2))]
    //    void Code();
    //}

    //public class CSharpDeveloperMixin : IDeveloper
    //{
    //    public void Code() {
    //        Console.WriteLine("C# coding");
    //    }
    //}

    //public class InterceptionAspectImpl2 : ActionInterceptionAspect
    //{
    //    public override void OnInvoke(ActionInterceptionArgs args) {
    //        Console.WriteLine("OnInvoke of AnInterceptionAspect");
    //        base.OnInvoke(args);
    //    }
    //}

    //public class AnotherInterceptionAspectImpl2 : ActionInterceptionAspect
    //{
    //    public override void OnInvoke(ActionInterceptionArgs args) {
    //        Console.WriteLine("OnInvoke of AnotherInterceptionAspect");
    //        base.OnInvoke(args);
    //    }
    //}

    class Program
    {
        //static void Main(string[] args) {
        //    IDeveloper developer = null;
        //    var container = new CompositeContainer(new CompositeRuntimeSettings {
        //        Types = new[] { typeof(IDeveloper) }
        //    });

        //    container.Configure();
        //    developer = container.Resolve<IDeveloper>();
        //    developer.Code();
        //}

        static void Main(string[] args) {
            CompositeRunner.Run();
        }
    }
}