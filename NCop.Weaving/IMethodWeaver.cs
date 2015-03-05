using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodWeaver : IWeaver
    {
		MethodBuilder DefineMethod();
		IMethodEndWeaver MethodEndWeaver { get; }
		void WeaveEndMethod(ILGenerator ilGenerator);
		IMethodScopeWeaver MethodScopeWeaver { get; }
        IMethodSignatureWeaver MethodDefintionWeaver { get; }
        void WeaveMethodScope(ILGenerator ilGenerator);
    }
}
