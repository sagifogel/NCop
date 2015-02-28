using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = false, Inherited = true)]
    public class EventInterceptionAspectAttribute : AspectAttribute
    {
		public EventInterceptionAspectAttribute(Type aspectType) 
			: base(aspectType) {
		}
    }
}
