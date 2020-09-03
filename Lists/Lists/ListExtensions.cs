using System;
using LanguageExt;
using static LanguageExt.List;
using static LanguageExt.Prelude;

namespace Lists
{

    public static class ListExtensions
    {
        //  InsertAt

        public static Lst<T> InsertAt<T>(this Lst<T> @this, int m, T value)
            => new Lst<T>(m != 0? append(create(head(@this)), rhs: tail(@this).InsertAt(m - 1, value)
                : append(create(value), @this));

        // RemoveAt

        public static Lst<T> RemoveAt<T>(this Lst<T> @this, int m)
            => new Lst<T>(m == 0
                ? tail(@this)
                : append(create<T>(head(@this)), ((Lst<T>)tail(@this)).RemoveAt(m - 1)));

        // TakeWhile

        public static Lst<T> TakeWhile<T>(this Lst<T> @this, Func<T, bool> pred)
            => new Lst<T>(@this.Match(
                () => @this,
                (hd, tl) => pred(hd)
                    ? append(create<T>(hd), ((Lst<T>)tail(tl)).TakeWhile(pred))
                    : create<T>()));

        // DropWhile

        public static Lst<T> DropWhile<T>(this Lst<T> @this, Func<T, bool> pred)
            => new Lst<T>(@this.Match(
                () => @this,
                (hd, tl) => pred(hd)
                    ? createRange(tl).DropWhile(pred) 
                    : @this));
    }
}