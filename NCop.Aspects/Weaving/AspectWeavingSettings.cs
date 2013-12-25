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
	internal class AspectWeavingSettings : IAspectWeavingSettings
	{
		internal static AspectWeavingSettings Empty = new AspectWeavingSettings();

		public IWeavingSettings WeavingSettings { get; set; }

		public IAspectRepository AspectRepository { get; set; }

		public IAspectArgsMapper AspectArgsMapper { get; set; }

		public ILocalBuilderRepository LocalBuilderRepository { get; set; }
	}
}
