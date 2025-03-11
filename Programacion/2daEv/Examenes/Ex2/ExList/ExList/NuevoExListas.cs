using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenList
{
    class NuevoExListas<T>
    {
        private T[] _array;
        private int _count;

        public NuevoExListas(T[] array, int count)
        {
            _array = array;
            _count = count;
        }
    }
}
