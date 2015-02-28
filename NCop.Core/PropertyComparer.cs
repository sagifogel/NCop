using System.Reflection;

namespace NCop.Core
{
    public static class PropertyComparer
    {
        public static bool IsMatchedTo(this PropertyInfo firstProperty, PropertyInfo secondProperty) {
            if (!firstProperty.Name.Equals(secondProperty.Name) || !MatchAccessModifier(firstProperty, secondProperty)) {
                return false;
            }

            return ReferenceEquals(firstProperty.PropertyType, secondProperty.PropertyType) ||
                   TypeComparer.Compare(firstProperty.PropertyType, secondProperty.PropertyType);
        }

        private static bool MatchAccessModifier(PropertyInfo firstProperty, PropertyInfo secondProperty) {
            if (firstProperty.CanRead && !secondProperty.CanRead || !firstProperty.CanRead && secondProperty.CanRead ||
                firstProperty.CanWrite && !secondProperty.CanWrite || firstProperty.CanWrite && !secondProperty.CanWrite) {
                return false;
            }

            return true;
        }
    }
}
