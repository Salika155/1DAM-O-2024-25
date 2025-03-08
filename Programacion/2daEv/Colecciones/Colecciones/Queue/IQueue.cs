using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Queue
{
    interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T FirstElement();
        T Last();
        bool IsEmpty();
        void Clear();
        int CountElement();

    }
}
