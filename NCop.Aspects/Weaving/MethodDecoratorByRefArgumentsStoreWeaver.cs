using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorByRefArgumentsStoreWeaver : IByRefArgumentsStoreWeaver
    {
        private readonly ParameterInfo[] parameters = null;
        private readonly Type previousAspectArgType = null;
        private readonly ISet<int> byRefParamslocalBuilderMap = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;

        internal MethodDecoratorByRefArgumentsStoreWeaver() {

        }

        public bool ContainsByRefParams {
            get {
                return parameters.Length > 0;
            }
        }

        public void StoreArgsIfNeeded(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }

        public void RestoreArgsIfNeeded(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }

        public bool Contains(int argPosition) {
            return byRefParamslocalBuilderMap.Contains(argPosition);
        }
    }
}
