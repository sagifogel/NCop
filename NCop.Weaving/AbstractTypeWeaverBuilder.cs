using System;
using System.Collections.Generic;

namespace NCop.Weaving
{
    public abstract class AbstractTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag, IPropertyWeaverBuilderBag
    {
        protected readonly Type type = null;
        protected readonly ITypeDefinition typeDefinition = null;
        protected readonly List<IMethodWeaver> methodWeavers = null;
        protected readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;
        protected readonly List<IPropertyWeaverBuilder> propertyWeaversBuilders = null;

        protected AbstractTypeWeaverBuilder(Type type, ITypeDefinition typeDefinition) {
            this.type = type;
            this.typeDefinition = typeDefinition;
            methodWeavers = new List<IMethodWeaver>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            propertyWeaversBuilders = new List<IPropertyWeaverBuilder>();
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public void Add(IPropertyWeaverBuilder item) {
            propertyWeaversBuilders.Add(item);
        }

        public abstract ITypeWeaver Build();

        public virtual void AddMethodWeavers() {
            methodWeaversBuilders.ForEach(methodBuilder => {
                methodWeavers.Add(methodBuilder.Build());
            });
        }

        public virtual void AddPropertyWeavers() {
            propertyWeaversBuilders.ForEach(propertyBuilder => {
                var propertyWeaver = propertyBuilder.Build();

                if (propertyWeaver.CanRead) {
                    methodWeavers.Add(propertyWeaver.GetGetMethod());
                }

                if (propertyWeaver.CanWrite) {
                    methodWeavers.Add(propertyWeaver.GetSetMethod());
                }
            });
        }
    }
}
