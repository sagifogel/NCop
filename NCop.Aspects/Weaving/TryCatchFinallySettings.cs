using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class TryCatchFinallySettings
    {
        public TryCatchFinallySettings(Type aspectArgumentType, ILocalBuilderRepository localBuilderRepository) {
            AspectArgumentType = aspectArgumentType;
            LocalBuilderRepository = localBuilderRepository;
        }

        public Type AspectArgumentType { get; private set; }
        public ILocalBuilderRepository LocalBuilderRepository { get; private set; }
    }
}
