using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Collections;
using System.Collections.Generic;
using  System.Linq;

namespace NCop.Aspects.Aspects
{
    public class AspectsMap : IAspectsMap
    {
        private readonly List<AspectMap> map = null;

        public AspectsMap(IAspectMemebrsCollection aspectMembers) {
            var mapper = new AspectAttributesMemberMatcher(aspectMembers);

            map = new List<AspectMap>(mapper);
            EnsureValidAspects(map);
        }

        private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
            aspectsMap.ForEach(aspectMap => {
                aspectMap.Aspects.ForEach(aspectDefinition => {
                    AspectValidator.ValidateAspect(aspectDefinition.Aspect, aspectMap);
                });
            });
        }

        public int Count {
            get {
                return map.Count;
            }
        }

        public IEnumerator<AspectMap> GetEnumerator() {
            return map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
