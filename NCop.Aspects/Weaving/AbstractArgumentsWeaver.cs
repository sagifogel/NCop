using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
	internal abstract class AbstractArgumentsWeaver : ArgumentsWeavingSettings, IArgumentsWeaver
	{
		protected readonly IAspectWeavingSettings aspectWeavingSettings = null;

		public AbstractArgumentsWeaver(Type argumentType, Type[] parameters, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository) {
			var @params = new Type[parameters.Length];

			ArgumentType = argumentType;
			parameters.CopyTo(@params, 0);
			Parameters = @params;
			LocalBuilderRepository = localBuilderRepository;
			IsFunction = argumentType.IsFunctionAspectArgs();
			this.aspectWeavingSettings = aspectWeavingSettings;
			WeavingSettings = aspectWeavingSettings.WeavingSettings;
		}

		public IWeavingSettings WeavingSettings { get; protected set; }

		public ILocalBuilderRepository LocalBuilderRepository { get; protected set; }

		public abstract void Weave(ILGenerator ilGenerator);
	}
}
