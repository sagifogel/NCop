using System;
using System.Collections.Generic;

namespace NCop.Weaving
{
    public abstract class AbstractTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag
    {
        protected readonly Type type = null;
		protected readonly ITypeDefinition typeDefinition = null;
		protected readonly List<IMethodWeaver> methodWeavers = null;
        protected readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;

        protected AbstractTypeWeaverBuilder(Type type, ITypeDefinition typeDefinition) {
            this.type = type;
            methodWeavers = new List<IMethodWeaver>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            this.typeDefinition = typeDefinition;
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public virtual ITypeWeaver Build() {
            AddMethodWeavers();
            
            return CreateTypeWeaver();
        }

        public virtual void AddMethodWeavers() {
            methodWeaversBuilders.ForEach(methodBuilder => {
                methodWeavers.Add(methodBuilder.Build());
            });
        }

        public abstract ITypeWeaver CreateTypeWeaver();
    }
}
