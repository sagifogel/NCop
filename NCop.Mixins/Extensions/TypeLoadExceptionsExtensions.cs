using System;
using System.Text.RegularExpressions;

namespace NCop.Mixins.Extensions
{
    public static class TypeLoadExceptionsExtensions
    {
        private static readonly Regex partialWeavingRegex = new Regex(".*does not have an implementation", RegexOptions.Compiled);

        internal static bool IsPartialWeavingException(this TypeLoadException ex) {
            return partialWeavingRegex.IsMatch(ex.Message);
        }
    }
}
