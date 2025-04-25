using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExListaEV2Ex1BienHecho
{
    class ExList1<T>
    {
        private T[] _arrayList = [];
        private int _count = 0;

        public int Capacity => _arrayList.Length;
        public int Count => _count;

        public T First
        {
            get
            {
                if (Empty)
                    throw new Exception();
                    return _arrayList[0];
            }  
        }
        public T Last
        {
            get
            {
                if (Empty)
                    throw new Exception();
                return _arrayList[Count - 1];
            }
        }

        public bool Empty => Count == 0;
    }
}
