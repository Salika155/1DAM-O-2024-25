using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCorregidoLista2
{
    public delegate bool FilterDelegate<T>(T value);
    public delegate void VisitDelegate<T>(T value);
    public delegate int SortDelegate<T>(T a, T b);
    public class ExList<T>
    {
        //es mejor crearlo asi
        private T[] _items = [];
        private int _count = 0;

        public ExList()
        {

        }

        public int Count => _count;
        public int Capacity => _items.Length;
        public ExList<T> Reversed => GetReversed();

        //indexer -> sustituye getelementat
        public T this[int index]
        {
            get => (index < 0 || index >= _count) ?  default(T) : _items[index];
            set 
                { //llamo a funcion setelementat

                }
        }
        private ExList<T> GetReversed()
        {
            ExList<T> result = new();
            result._items = new T[Count];
            result._count = _count;
            //for
            return result;
        }

        //GetElementAt

        public void AddElement(T element)
        {
            if (Count == Capacity)
            {
                //creo array nuevo copio el antiguo menos la ultima posicion

            }
            _items[_count++] = element;
        }

        //removeat reduce el count y desplaza elementos
        public void RemoveAt(int index)
        {
            for (int i = index; i < _items.Length; i++)
            {

            }
        }

        public void Clear()
        {
            //habia que hacer esto si son numeros, si son objetos utilizaria default(T)
            _count = 0;
        }

        //en el insert haria lo mismo que en el add de count == capacity -> sacaria otra funcion para reescalar eso y llamarlo en las dos funciones.

        public int IndexOf(T element)
        {
            for (int i = 0; i < _count; i++)
                if (EqualityComparer<T>.Default.Equals(element))
                    return i;
            //if (_items[0].Equals(element))
            //    return 0;
            return -1;
        }

        //Contains una linea llamando indexof

        public int IndexOfDelegate(FilterDelegate<T> filter)
        {
            if (filter == null)
                return -1;

            for (int i = 0; i < _count; i++)
            {
                if (filter(_items[i]))
                    return i;
            }
            return -1;
        }

        public void Visit(VisitDelegate<T> visit)
        {
            if (visit == null)
                return;
            //foreach (var item in _items)
            //    visit(item);
            //for de _count;
        }

        public void Sort()
        {
            //for ()
            //{
            //    for()
            //    {
            //        if (del(item[i], _item[j]))
            //        {

            //        }
            //    }
            //}
        }

        //Clone hacer array nuevo y con un for



    }
}
