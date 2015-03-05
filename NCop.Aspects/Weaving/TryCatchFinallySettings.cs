using System;

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
