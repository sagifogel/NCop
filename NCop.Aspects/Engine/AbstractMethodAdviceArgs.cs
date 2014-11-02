using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractMethodAdviceArgs : AbstractAdviceArgs
    {
        public MethodInfo Method { get; set; }
    }
}
