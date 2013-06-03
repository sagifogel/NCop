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
            foreach (TSource item in source) {
                action(item, seed++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action) {
            int count = 0;

            foreach (TSource item in source) {
                action(item, count++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (TSource item in source) {
                action(item);
            }
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
            int count = 0;

            foreach (TSource local in source) {
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

        public static IEnumerable<TSource> NullCoalesce<TSource>(this IEnumerable<TSource> source) {
            return source ?? Enumerable.Empty<TSource>();
        }

        public static IEnumerable<TSource> SelfJoin<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> second) {
            if (source != second) {
                source = source.Concat(second);
            }

            return source;
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
            HashSet<TKey> keys = new HashSet<TKey>();

            foreach (TSource element in source) {
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

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            int index = -1;
            int count = -1;

            foreach (var item in source) {
                count++;

                if (predicate(item)) {
                    index = count;
                    break;
                }
            }

            return index;
        }

        public static ConcurrentDictionary<TKey, TSource> ToThreadSafeDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            return ToThreadSafeDictionary(source, local => keySelector(local), local => local);
        }

        public static ConcurrentDictionary<TKey, TValue> ToThreadSafeDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector) {
            return new ConcurrentDictionary<TKey, TValue>(
                    source.ToDictionary(local => keySelector(local), local => elementSelector(local)));
        }

        public static TValue SafeGetOrAdd<TKey, TValue>(this ConcurrentDictionary<TKey, Lazy<TValue>> source, TKey key, Func<TKey, TValue> valueFactory) {
            return source.GetOrAdd(key, new Lazy<TValue>(() => valueFactory(key))).Value;
        }

        public static TValue SafeAddOrUpdate<TKey, TValue>(this ConcurrentDictionary<TKey, Lazy<TValue>> source, TKey key, TValue addValue, Func<TKey, TValue> updateValueFactory) {
            return source.AddOrUpdate(key, new NCop.Core.Lazy<TValue>(() => addValue), (k, lazy) => new NCop.Core.Lazy<TValue>(() => updateValueFactory(key))).Value;
        }

        public static ISet<TSource> ToSet<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null) {
            if (predicate != null) {
                source = source.Where(predicate);
            }

            return new HashSet<TSource>(source);
        }
    }
}