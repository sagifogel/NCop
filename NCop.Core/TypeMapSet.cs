using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core
{
    public class TypeMapSet : ITypeMap
    {
        private readonly HashSet<TypeMap> maps = null;

        public TypeMapSet() {
            maps = new HashSet<TypeMap>();
        }

        public int Count {
            get { 
                return maps.Count;
            }
        }

        public void Add(TypeMap map) {
            maps.Add(map);
        }

        public IEnumerator<TypeMap> GetEnumerator() {
            return maps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}
