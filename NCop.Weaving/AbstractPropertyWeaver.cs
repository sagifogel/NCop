using System;
using System.Reflection;

namespace NCop.Weaving
{
    public abstract class AbstractPropertyWeaver : IPropertyWeaver, IWeavingSettings
    {
        protected PropertyInfo property = null;
        private readonly IWeavingSettings weavingSettings = null;

        protected AbstractPropertyWeaver(PropertyInfo property, IWeavingSettings weavingSettings) {
            this.property = property;
            this.weavingSettings = weavingSettings;
        }

        public abstract IMethodWeaver GetGetMethod();

        public abstract IMethodWeaver GetSetMethod();

        public bool CanRead {
            get {
                return property.CanRead;
            }
        }

        public bool CanWrite {
            get {
                return property.CanWrite;
            }
        }

        public Type ContractType {
            get {
                return weavingSettings.ContractType;
            }
        }

        public ITypeDefinition TypeDefinition {
            get {
                return weavingSettings.TypeDefinition;
            }
        }
    }
}
