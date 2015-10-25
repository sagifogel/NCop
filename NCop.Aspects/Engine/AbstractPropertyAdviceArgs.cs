using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractPropertyAdviceArgs : AbstractAdviceArgs
    {   
        public PropertyInfo Property { get; set; }
    }
}
