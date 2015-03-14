
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;
namespace NCop.Composite.Weaving
{
    internal class CompositePropertyWeaver : IPropertyWeaver, IPropertyTypeBuilder
    {
        private IMethodWeaver getMethodWeaver = null;
        private IMethodWeaver setMethodWeaver = null;
        private readonly Core.Lib.Lazy<PropertyBuilder> lazyPropertyBuilder = null;

        public CompositePropertyWeaver(ITypeDefinition typeDefinition, PropertyInfo property) {
            lazyPropertyBuilder = new Core.Lib.Lazy<PropertyBuilder>(() => {
                return typeDefinition.TypeBuilder.DefineProperty(property);
            });
        }

        public bool CanRead {
            get {
                return getMethodWeaver.IsNotNull();
            }
        }

        public bool CanWrite {
            get {
                return setMethodWeaver.IsNotNull();
            }
        }

        public void SetGetMethodWeaver(IMethodWeaver getMethodWeaver) {
            this.getMethodWeaver = getMethodWeaver;
        }

        public void SetSetMethodWeaver(IMethodWeaver setMethodWeaver) {
            this.setMethodWeaver = setMethodWeaver;
        }

        public IMethodWeaver GetGetMethod() {
            return getMethodWeaver;
        }

        public IMethodWeaver GetSetMethod() {
            return setMethodWeaver;
        }

        public void SetGetMethod(MethodBuilder method) {
            lazyPropertyBuilder.Value.SetGetMethod(method);
        }

        public void SetSetMethod(MethodBuilder method) {
            lazyPropertyBuilder.Value.SetSetMethod(method);
        }
    }
}
