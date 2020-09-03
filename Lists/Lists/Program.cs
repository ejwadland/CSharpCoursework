using System;
using LanguageExt;
using static LanguageExt.List;
using static LanguageExt.Prelude;
using static ListExtensions;

namespace Lists
{
    internal static class Program
    {
        public static void Main()
        {
            var l1 = create(3, 4, 5, 6, 7, 8);
            Console.WriteLine($"List: {l1}");
            var l2 = l1.InsertAt(5, 10);
            Console.WriteLine($"List: {l2}");
        }
    }
}
