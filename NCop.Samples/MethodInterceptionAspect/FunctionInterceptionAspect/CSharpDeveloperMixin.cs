
namespace NCop.Samples.MethodInterceptionAspect.FunctionInterceptionAspect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public string Code(string code) {
            return "From mixin " + code;
        }
    }
}
