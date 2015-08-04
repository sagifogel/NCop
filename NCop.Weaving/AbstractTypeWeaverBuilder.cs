using System;
using System.Collections.Generic;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    public abstract class AbstractTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag, IPropertyWeaverBuilderBag, IEventWeaverBuilderBag
    {
        protected readonly Type type = null;
        protected readonly List<IMethodWeaver> methodWeavers = null;
        protected readonly List<IEventWeaverBuilder> eventWeaversBuilders = null;
        protected readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;
        protected readonly List<IPropertyWeaverBuilder> propertyWeaversBuilders = null;

        protected AbstractTypeWeaverBuilder(Type type) {
            this.type = type;
            methodWeavers = new List<IMethodWeaver>();
            eventWeaversBuilders = new List<IEventWeaverBuilder>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            propertyWeaversBuilders = new List<IPropertyWeaverBuilder>();
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public void Add(IPropertyWeaverBuilder item) {
            propertyWeaversBuilders.Add(item);
        }

        public void Add(IEventWeaverBuilder item) {
            eventWeaversBuilders.Add(item);
        }

        public abstract ITypeWeaver Build();

        public virtual void AddEventWeavers() {
            eventWeaversBuilders.ForEach(eventBuilder => {
                AddMethodWeavers(eventBuilder.Build());
            });
        }

        public virtual void AddMethodWeavers() {
            methodWeaversBuilders.ForEach(methodBuilder => {
                AddMethodWeaver(methodBuilder.Build());
            });
        }

        protected virtual void AddPropertyWeavers() {
            propertyWeaversBuilders.ForEach(propertyBuilder => {
                AddMethodWeavers(propertyBuilder.Build());
            });
        }

        public virtual void AddMethodWeaver(IMethodWeaver methodWeaver) {
            methodWeavers.Add(methodWeaver);
        }

        public virtual void AddMethodWeavers(IEnumerable<IMethodWeaver> methodWeaversSource) {
            methodWeaversSource.ForEach(methodWeaver => AddMethodWeaver(methodWeaver));
        }
    }
}
