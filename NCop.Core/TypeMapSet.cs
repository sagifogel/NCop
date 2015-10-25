using System.Collections;
using System.Collections.Generic;

namespace NCop.Core
{
    public class TypeMapSet : ITypeMapCollection
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
            return GetEnumerator();
        }
    }
}
