using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Parser
{
    public static class StringExtension
    {
        private static Option<T> Parse<T>(this string s) where T : struct
            => Enum.TryParse(s, out T t) ? Some(t) : None;

        static void Main(string[] args)
        {
            var s = "Friday".Parse<DayOfWeek>();
            Console.WriteLine(s);
            s = "Freeday".Parse<DayOfWeek>;
            Console.WriteLine(s);

            var t = Enum.Parse<DayOfWeek>("Friday");
            Console.WriteLine(t);
            t = Enum.Parse<DayOfWeek>("Freeday");
            Console.WriteLine(t);
        }
    }
}
