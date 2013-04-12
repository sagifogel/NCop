using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Extensions
{
    public static class StringExtensions
    {
        private static readonly int _lowerCaseOffset = 'a' - 'A';

        public static string ToCamelCase(this string value) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            }

            var length = value.Length;
            var newValue = new char[length];
            var firstPart = true;

            for (var i = 0; i < length; ++i) {
                var c0 = value[i];
                var c1 = i < length - 1 ? value[i + 1] : 'A';
                var c0isUpper = c0 >= 'A' && c0 <= 'Z';
                var c1isUpper = c1 >= 'A' && c1 <= 'Z';

                if (firstPart && c0isUpper && (c1isUpper || i == 0)) {
                    c0 = (char)(c0 + _lowerCaseOffset);
                }
                else {
                    firstPart = false;
                }

                newValue[i] = c0;
            }

            return new string(newValue);
        }

        public static string ToLowercaseUnderscore(this string value) {
            StringBuilder stringBuilder = null;

            if (string.IsNullOrEmpty(value)) {
                return value;
            }

            stringBuilder = new StringBuilder(value.Length);

            foreach (var t in value) {
                if (char.IsLower(t) || t == '_') {
                    stringBuilder.Append(t);
                }
                else {
                    stringBuilder.Append("_");
                    stringBuilder.Append(char.ToLowerInvariant(t));
                }
            }

            return stringBuilder.ToString();
        }

        public static string ToUnderscoreFieldName(this string value) {
            if (string.IsNullOrEmpty(value) || value.Length == 1) {
                return value;
            }

            return new StringBuilder(value.Substring(1)).ToString().ToLowercaseUnderscore();
        }
    }
}
