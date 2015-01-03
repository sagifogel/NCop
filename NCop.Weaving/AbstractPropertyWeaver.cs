using System;
using System.Reflection;

namespace NCop.Weaving
{
    public abstract class AbstractPropertyWeaver : IPropertyWeaver, IPropertyWeavingSettings
    {
        protected PropertyInfo propertyInfo = null;
        private readonly IWeavingSettings weavingSettings = null;

        protected AbstractPropertyWeaver(PropertyInfo propertyInfo, IWeavingSettings weavingSettings) {
            this.propertyInfo = propertyInfo;
            this.weavingSettings = weavingSettings;
        }

        public abstract IMethodWeaver GetGetMethod();

        public abstract IMethodWeaver GetSetMethod();

        public bool CanRead {
            get {
                return propertyInfo.CanRead;
            }
        }

        public bool CanWrite {
            get {
                return propertyInfo.CanWrite;
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
