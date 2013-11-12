using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Weaving
{
    public abstract class AbstractTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag, IPropertyWeaverBag
    {
        protected readonly Type type = null;
        protected readonly List<IMethodWeaver> methodWeavers = null;
        protected readonly ITypeDefinitionFactory typeDefinitionFactory = null;
        protected readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;
        protected readonly List<IPropertyWeaverBuilder> propertyWeaversBuilders = null;

        public AbstractTypeWeaverBuilder(Type type, ITypeDefinitionFactory typeDefinitionFactory) {
            this.type = type;
            methodWeavers = new List<IMethodWeaver>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            propertyWeaversBuilders = new List<IPropertyWeaverBuilder>();
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public void Add(IPropertyWeaverBuilder item) {
            propertyWeaversBuilders.Add(item);
        }

        public virtual ITypeWeaver Build() {
            AddMethodWeavers();
            
            return CreateTypeWeaver();
        }

        public virtual void AddMethodWeavers() {
            methodWeaversBuilders.ForEach(methodBuilder => {
                methodWeavers.Add(methodBuilder.Build());
            });

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

        public abstract ITypeWeaver CreateTypeWeaver();
    }
}
