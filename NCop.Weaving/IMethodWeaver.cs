using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodWeaver : IWeaver
    {
        MethodBuilder DefineMethod();
        MethodBuilder MethodBuilder { get; }
        IMethodEndWeaver MethodEndWeaver { get; }
        void WeaveEndMethod(ILGenerator ilGenerator);
        IMethodScopeWeaver MethodScopeWeaver { get; }
        void WeaveMethodScope(ILGenerator ilGenerator);
    }
}
