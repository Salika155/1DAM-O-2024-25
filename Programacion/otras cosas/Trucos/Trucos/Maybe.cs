using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucos
{
    public class Maybe<T>
    {
        private readonly T _value;
        public Maybe(T value)
        {
            _value = value;
        }

        public Maybe<U> Bind<U>(Func<T, Maybe<U>> func)
        {
            return _value != null ? func(_value) : new Maybe<U>(default);
        }

        public T Value => _value;

        //Maybe<int> MaybeDivide(int x, int y)
        //{
        //    if (y == 0)
        //        return new Maybe<int>(null); // No hay valor si hay división por cero.
        //    return new Maybe<int>(x / y);
        //}

        //Maybe<int> MaybeAddFive(int x)
        //{
        //    return new Maybe<int>(x + 5);
        //}


    }

}
