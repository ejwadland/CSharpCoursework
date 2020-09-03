using System;
using LanguageExt;
using System.Collections.Generic;
using static LanguageExt.Prelude;


namespace Lookup
{
    public static class EnumerableExtension
    {

        private static Option<T> Lookup<T>(this IEnumerable<T> ts, Func<T, bool> pred)
        {
            foreach (var t in ts)
                if (pred(t))
                    return Some(t);
            return None;
        }

        static void Main(string[] args)
        {
            bool isOdd(int i) => i % 2 == 1;
            Console.WriteLine(new List<int>().Lookup(isOdd));
            Console.WriteLine(new List<int> { 1 }.Lookup(isOdd));
        }
    }
}
