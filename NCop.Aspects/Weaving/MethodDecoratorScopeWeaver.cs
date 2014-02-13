using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorScopeWeaver : IMethodScopeWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly ICanEmitLocalBuilderByRefArgumentsWeaver byRefArgumentsStoreWeaver = null;

        internal MethodDecoratorScopeWeaver(IAspectWeavingSettings aspectWeavingSettings) {
            Type aspectArgumentContract = null;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var weavingSettings = aspectWeavingSettings.WeavingSettings;

            this.aspectWeavingSettings = aspectWeavingSettings;
            methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();
            byRefArgumentsStoreWeaver = new MethodDecoratorByRefArgumentsStoreWeaver(aspectArgumentContract, methodInfoImpl, localBuilderRepository);
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(methodInfoImpl, byRefArgumentsStoreWeaver);
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            var isFunction = methodInfoImpl.IsFunction();
            var weaveFunction = isFunction ? WeaveFunction : (Func<ILGenerator, ILGenerator>)WeaveAction;

            return weaveFunction(ilGenerator);
        }

        private ILGenerator WeaveAction(ILGenerator ilGenerator) {
            var aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();

            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);

            return ilGenerator;
        }

        private ILGenerator WeaveFunction(ILGenerator ilGenerator) {
            var aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();
            var setReturnValueWeaver = new SetReturnValueWeaver(aspectArgumentContract);
            var returnValueGetMethod = aspectArgumentContract.GetProperty("ReturnValue");

            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod.GetGetMethod());
            ilGenerator.Emit(OpCodes.Ret);

            return ilGenerator;
        }
    }
}
