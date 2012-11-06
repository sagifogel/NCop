using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class WeaverVisitor
    {
        public IWeaver Visit(RuntimeWeaver weaver, AspectsRuntimeSettings settings) {
            return new RuntimeMixinsWeaver(weaver, settings);
        }
    }
}
