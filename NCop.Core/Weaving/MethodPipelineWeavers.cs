using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodPipelineWeavers
    {
        IMethodScopeWeaver MethodScopeWeaver { get; set; }
        IMethodSignatureWeaver SignatureWeaver { get; set; }
    }
}
