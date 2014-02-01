using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TResult>
    {
        TArg1 Arg1 { get; set; }
        MethodInfo Method { get; set; }
        TResult ReturnValue { get; set; }
    }
}
