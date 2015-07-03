using NCop.Core.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractByRefArgumentsStoreWeaver : IByRefArgumentsStoreWeaver
    {
        protected readonly ParameterInfo[] parameters = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

        internal AbstractByRefArgumentsStoreWeaver(MethodInfo method, ILocalBuilderRepository localBuilderRepository) {
            this.localBuilderRepository = localBuilderRepository;
            parameters = method.GetParameters().ToArray(param => param.ParameterType.IsByRef);
        }

        public bool ContainsByRefParams {
            get {
                return parameters.Length > 0;
            }
        }

        public abstract bool Contains(int argPosition);

        public abstract void StoreArgsIfNeeded(ILGenerator ilGenerator);

        public abstract void RestoreArgsIfNeeded(ILGenerator ilGenerator);

        public abstract void EmitLoadLocalAddress(ILGenerator ilGenerator, int argPosition);
    }
}
