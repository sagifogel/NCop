using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core.Extensions
{
    public static class TypeMapExtenisons
    {
        public static TypeMap CloneWithName (this TypeMap typeMap, string name){
            return new TypeMap(typeMap.ServiceType, typeMap.ConcreteType, name);
        }
    }
}
