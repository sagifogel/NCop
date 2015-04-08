using NCop.Composite.Extensions;
using NCop.Core;
using NCop.IoC;
using System;

namespace NCop.Composite.Engine
{
    internal class CompositeRegistryDecorator : INCopDependencyAwareRegistry
    {
        private readonly INCopDependencyAwareRegistry regisrty = null;

        public CompositeRegistryDecorator(INCopDependencyAwareRegistry regisrty) {
            this.regisrty = regisrty;
        }

        public void Register(Type concreteType, Type serviceType, ITypeMap dependencies, string name = null, bool isComposite = false) {
            name = name ?? serviceType.GetNameFromAttribute() ?? concreteType.GetNameFromAttribute();

            regisrty.Register(concreteType, serviceType, dependencies, name, isComposite);
        }
    }
}
