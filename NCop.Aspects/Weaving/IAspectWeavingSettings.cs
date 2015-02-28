using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
	public interface IAspectWeavingSettings
	{
        IWeavingSettings WeavingSettings { get; }
		IAspectRepository AspectRepository { get; }
		IAspectArgsMapper AspectArgsMapper { get; }
		ILocalBuilderRepository LocalBuilderRepository { get; }
        IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; }
    }
}
