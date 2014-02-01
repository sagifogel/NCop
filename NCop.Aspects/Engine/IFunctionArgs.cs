using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TResult>
    {
        MethodInfo Method { get; set; }
        TResult ReturnValue { get; set; }
    }
}