using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
	internal class CompositeMethodWeaver : AbstractMethodWeaver
	{
		private readonly AspectMethodWeaver methodWeaver = null;

		internal CompositeMethodWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
			methodWeaver = new AspectMethodWeaver(aspectDefinitions, aspectWeavingSettings);
			MethodDefintionWeaver = methodWeaver.MethodDefintionWeaver;
			MethodScopeWeaver = methodWeaver.MethodScopeWeaver;
			MethodEndWeaver = methodWeaver.MethodEndWeaver;
		}

		public override MethodBuilder DefineMethod() {
			return MethodDefintionWeaver.Weave(MethodInfoImpl);
		}

		public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
			return MethodScopeWeaver.Weave(ilGenerator);
		}

		public override void WeaveEndMethod(ILGenerator ilGenerator) {
			MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
		}
	}
}
