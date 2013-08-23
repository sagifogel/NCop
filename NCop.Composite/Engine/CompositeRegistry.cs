using NCop.Composite.Framework;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.IoC.Fluent;

namespace NCop.Composite.Engine
{
	internal class CompositeRegistry : ContainerRegistry
	{
		public override IRegistration Register(Type concreteType, Type serviceType) {
			CompositeFrameworkRegistration compositeRegistration = null;

			if (IsNotIgnoreRegistration(concreteType, serviceType)) {
				Type castAs = null;
				CompositeAttribute compositeAttr = null;

				if (TryGetCompositeAttribute(concreteType, serviceType, out compositeAttr)) {
					castAs = compositeAttr.As;
				}

				compositeRegistration = new CompositeFrameworkRegistration(concreteType, serviceType, castAs);
				registrations.Add(compositeRegistration);
			}

			return compositeRegistration;
		}

		private bool IsNotIgnoreRegistration(Type concreteType, Type serviceType) {
			return !(concreteType.IsDefined<IgnoreRegistration>() ||
					 serviceType.IsDefined<IgnoreRegistration>());
		}

		private bool TryGetCompositeAttribute(Type concreteType, Type serviceType, out CompositeAttribute compositeAttribute) {
			compositeAttribute = concreteType.GetCustomAttribute<CompositeAttribute>() ??
								 serviceType.GetCustomAttribute<CompositeAttribute>();

			return compositeAttribute.IsNotNull();
		}
	}
}
