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
        public TryCatchFinallySettings(Type aspectArgumentType, FieldInfo aspectMember, ILocalBuilderRepository localBuilderRepository) {
            AspectMember = aspectMember;
            AspectArgumentType = aspectArgumentType;
            LocalBuilderRepository = localBuilderRepository;
        }

        public FieldInfo AspectMember { get; private set; }
        public Type AspectArgumentType { get; private set; }
        public ILocalBuilderRepository LocalBuilderRepository { get; private set; }
    }
}
