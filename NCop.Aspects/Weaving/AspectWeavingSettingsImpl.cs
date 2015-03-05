using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
	public class AspectWeavingSettingsImpl : IAspectWeavingSettings
	{
        public IWeavingSettings WeavingSettings { get; set; }
        public IAspectRepository AspectRepository { get; set; }
		public IAspectArgsMapper AspectArgsMapper { get; set; }
		public ILocalBuilderRepository LocalBuilderRepository { get; set; }
		public IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; set; }
	}
}
