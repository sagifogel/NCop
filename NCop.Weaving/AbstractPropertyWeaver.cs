using System;
using System.Reflection;

namespace NCop.Weaving
{
    public abstract class AbstractPropertyWeaver : IPropertyWeaver, IPropertyWeavingSettings
    {
        private readonly IPropertyWeavingSettings weavingSettings = null;

        protected AbstractPropertyWeaver(IPropertyWeavingSettings weavingSettings) {
            this.weavingSettings = weavingSettings;
        }

        public abstract IMethodWeaver GetGetMethod();

        public abstract IMethodWeaver GetSetMethod();

        public bool CanRead {
            get {
                return PropertyInfoImpl.CanRead;
            }
        }

        public bool CanWrite {
            get {
                return PropertyInfoImpl.CanWrite;
            }
        }

        public PropertyInfo PropertyInfoImpl {
            get {
                return weavingSettings.PropertyInfoImpl;
            }
        }

        public PropertyInfo PropertyInfoContract {
            get {
                return weavingSettings.PropertyInfoContract;
            }
        }

        public Type ContractType {
            get {
                return weavingSettings.ContractType;
            }
        }

        public Type ImplementationType {
            get {
                return weavingSettings.ImplementationType;
            }
        }

        public ITypeDefinition TypeDefinition {
            get {
                return weavingSettings.TypeDefinition;
            }
        }
    }
}
