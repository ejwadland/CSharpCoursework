using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

namespace MapExtension
{
    public static class MapExtension
    {
        static ISet<R> Map<T,R>(this ISet<T> ts, Func<T, R> func)
        {
            var rs = new LanguageExt.HashSet<R>();
            foreach (var t in ts)
                rs.Add(func(t));
            return rs as ISet<R>;
        }

        static IDictionary<K, R> Map<K, T, R>
            (this IDictionary<K, T> dict, Func<T, R> func)
        {
            var rs = new Dictionary<K, R>();
            foreach (var (key, value) in dict)
                rs[key] = func(value);
            return rs;
        }

        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> func)
            => opt.Bind(t => Some(func(t)));

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> func)
            => ts.Bind(t => List(func(t)));

        public static void Main(string[] args)
        {

        }
    }
   
}
