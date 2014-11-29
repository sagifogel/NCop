using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, int seed, Action<TSource, int> action) {
            foreach (var item in source) {
                action(item, seed++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action) {
            var count = 0;

            foreach (var item in source) {
                action(item, count++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (var item in source) {
                action(item);
            }
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
            int count = 0;

            foreach (var local in source) {
                if (!predicate(local, count++)) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source) {
            if (source == null) {
                return true;
            }

            return !source.Any();
        }

        public static bool IsNotNullOrEmpty<TSource>(this IEnumerable<TSource> source) {
            return !source.IsNullOrEmpty();
        }

        public static IEnumerable<TSource> NullCoalesce<TSource>(this IEnumerable<TSource> source) {
            return source ?? Enumerable.Empty<TSource>();
        }

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, params TSource[] second) {
            foreach (var item in source) {
                yield return item;
            }

            foreach (var item in second) {
                yield return item;
            }
        }

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, TSource second) {
            return source.Concat(new[] { second });
        }

        public static TResult SelectFirst<TItem, TInner, TResult>(this TItem item, IEnumerable<TInner> inner, Func<TItem, TInner, bool> predicate, Func<TItem, TInner, TResult> selector) {
            Func<TInner, TInner, bool> comparer = EqualityComparer<TInner>.Default.Equals;

            TInner innerResult = inner.FirstOrDefault(innerItem => predicate(item, innerItem));

            if (!comparer(innerResult, default(TInner))) {
                return selector(item, innerResult);
            }

            return default(TResult);
        }

        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> predicate) {
            var keys = new HashSet<TKey>();

            foreach (var element in source) {
                if (keys.Add(predicate(element))) {
                    yield return element;
                }
            }
        }

        public static TResult[] ToArrayOf<TResult>(this IEnumerable source) {
            return source.Cast<TResult>()
                         .ToArray();
        }

        public static List<TResult> ToListOf<TResult>(this IEnumerable source) {
            return source.Cast<TResult>()
                         .ToList();
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            return source.Where(predicate).ToList();
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            return source.Where(predicate).ToArray();
        }

        public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            return source.Select(selector).ToList();
        }

        public static TResult[] ToArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            return source.Select(selector).ToArray();
        }

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            var index = -1;
            var count = -1;

            foreach (var item in source) {
                count++;

                if (predicate(item)) {
                    index = count;
                    break;
                }
            }

            return index;
        }

        public static ISet<TSource> ToSet<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null) {
            if (predicate != null) {
                source = source.Where(predicate);
            }

            return new HashSet<TSource>(source);
        }

        public static void AddRange<TSource>(this ISet<TSource> source, IEnumerable<TSource> second) {
            second.ForEach(item => source.Add(item));
        }
    }
}