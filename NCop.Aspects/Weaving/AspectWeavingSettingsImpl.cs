using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
	public class AspectWeavingSettingsImpl : IAspectWeavingSettings
	{
		public IAspectRepository AspectRepository { get; set; }
		public IAspectArgsMapper AspectArgsMapper { get; set; }
		public IWeavingSettings WeavingSettings { get; set; }
		public ILocalBuilderRepository LocalBuilderRepository { get; set; }
		public IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; set; }
	}
}
