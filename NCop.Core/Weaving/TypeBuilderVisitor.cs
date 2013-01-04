using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving
{
    public class TypeWeaverBuilderVisitor : ITypeWeaverBuilderVisitor, IDisposable
    {
        private List<Action<Type, ITypeWeaverBuilder>> _typeSubscribers = null;
        private List<Action<MethodInfo, ITypeWeaverBuilder>> _methodSubscribers = null;
        private List<Action<PropertyInfo, ITypeWeaverBuilder>> _propertySubscribers = null;

        public TypeWeaverBuilderVisitor(ITypeWeaverBuilder typeBuilder) {
            TypeBuilder = typeBuilder;
            _typeSubscribers = new List<Action<Type, ITypeWeaverBuilder>>();
            _methodSubscribers = new List<Action<MethodInfo, ITypeWeaverBuilder>>();
            _propertySubscribers = new List<Action<PropertyInfo, ITypeWeaverBuilder>>();
        }

        public ITypeWeaverBuilder TypeBuilder { get; private set; }

        public void Subscribe(Action<Type, ITypeWeaverBuilder> action) {
            _typeSubscribers.Add(action);
        }

        public void Subscribe(Action<MethodInfo, ITypeWeaverBuilder> action) {
            _methodSubscribers.Add(action);
        }

        public void Subscribe(Action<PropertyInfo, ITypeWeaverBuilder> action) {
            _propertySubscribers.Add(action);
        }

        public void Visit(Type type) {
            _typeSubscribers.ForEach(action => action(type, TypeBuilder));
        }

        public void Visit(MethodInfo method) {
            _methodSubscribers.ForEach(action => action(method, TypeBuilder));
        }

        public void Visit(PropertyInfo property) {
            _propertySubscribers.ForEach(action => action(property, TypeBuilder));
        }

        private void Visit(MemberInfo memeberInfo, ITypeWeaverBuilder builder) { }

        public void Dispose() {
            _typeSubscribers.Clear();
            _methodSubscribers.Clear();
            _propertySubscribers.Clear();
        }
    }
}
