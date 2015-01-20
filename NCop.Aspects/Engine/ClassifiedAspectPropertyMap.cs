using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
    internal class ClassifiedAspectPropertyMap
    {
        private readonly ISet<IAspectPropertyMap> getProperties = new HashSet<IAspectPropertyMap>();
        private readonly ISet<IAspectPropertyMap> setProperties = new HashSet<IAspectPropertyMap>();
        private readonly ISet<IAspectPropertyMap> bothAccessorsProperties = new HashSet<IAspectPropertyMap>();

        internal ClassifiedAspectPropertyMap(IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                var getMethodIsNotNull = propertyMap.AspectGetProperty.IsNotNull();
                var setMethodIsNotNull = propertyMap.AspectSetProperty.IsNotNull();

                if (getMethodIsNotNull && setMethodIsNotNull) {
                    bothAccessorsProperties.Add(propertyMap);
                }
                else if (getMethodIsNotNull) {
                    getProperties.Add(propertyMap);
                }
                else {
                    setProperties.Add(propertyMap);
                }
            });
        }

        public IEnumerable<IAspectPropertyMap> GetProperties {
            get {
                return getProperties;
            }
        }

        public IEnumerable<IAspectPropertyMap> SetProperties {
            get {
                return setProperties;
            }
        }

        public IEnumerable<IAspectPropertyMap> BothAccessorsProperties {
            get {
                return bothAccessorsProperties;
            }
        }
    }
}
