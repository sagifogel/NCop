using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
