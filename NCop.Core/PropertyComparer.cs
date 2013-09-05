using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
	public static class PropertyComparer
	{
		public static bool IsMatchedTo(this PropertyInfo firstProperty, PropertyInfo secondProperty) {
			if (!firstProperty.Name.Equals(secondProperty.Name) || !MatchAccessModifier(firstProperty, secondProperty)) {
				return false;
			}

			return firstProperty.PropertyType.Equals(secondProperty.PropertyType) ||
				   TypeComparer.Compare(firstProperty.PropertyType, secondProperty.PropertyType);
		}

		private static bool MatchAccessModifier(PropertyInfo firstProperty, PropertyInfo secondProperty) {
			if (firstProperty.CanRead && !secondProperty.CanRead || !firstProperty.CanRead && secondProperty.CanRead ||
				firstProperty.CanWrite && !secondProperty.CanWrite || firstProperty.CanRead && !secondProperty.CanWrite) {
				return false;
			}

			return true;
		}
	}
}
