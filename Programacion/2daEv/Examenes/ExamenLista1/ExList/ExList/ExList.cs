using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenList
{
    public delegate void Visit<T>(T[] array);
    public delegate bool FilterDelegate<T>(T filter);
    internal class ExList<T>
    {

        private T[] _arrayList = new T[0];
        private T? _item;


        public class Item<T>
        {
            private readonly List<T> _elementosLista = new List<T>();
            private int _count;

            public int CountElements => _elementosLista.Count;

            public T First
            {
                get
                {
                    if (Empty)
                    {
                        throw new Exception("No existen elementos en la lista");
                    }
                    var itemfirst = _elementosLista[0];
                    return itemfirst;
                }
            }

            public T Last
            {
                get
                {
                    if(Empty)
                        throw new Exception("No existen elementos en la lista");
                    var itemlast = _elementosLista[_elementosLista.Count];
                    return itemlast;
                }
            }
            public bool Empty => _elementosLista.Count == 0;

            //public T? GetElementAt(int index)
            //{
            //    if (index < 0 || index >= _elementosLista.Count)
            //        return default;
            //    for (int i = 0; i < _elementosLista.Count; i++)
            //    {
            //        var element = _elementosLista[i];
            //        if (_elementosLista[index] = )
            //            return ;
            //    }

            //}
            
            public void Add(T element)
            {
                _elementosLista.Add(element);
            }


        }

        //Count
        public int Count => _arrayList.Length - 1;
        //Capacity
        public int Capacity => _arrayList.Length;
        public bool Empty => _arrayList.Length == 0;
        //First
        public T First
        {
            get
            {
                if (Empty)
                {
                    throw new Exception("No existen elementos en la lista");
                }
                var itemfirst = _arrayList[0];
                return itemfirst;
            }
        }

        //Last
        public T Last
        {
            get
            {
                if (Empty)
                {
                    throw new Exception("No existen elementos en la lista");
                }
                var last = _arrayList[_arrayList.Length - 1];
                return last;
            }
        }
        public T? ItemList
        {
            get => _item;
            set => _item = value;
        }


        public T? GetElementAt(int index)
        {
            if (index < 0 || index >= _arrayList.Length)
                return default;

            for (int i = 0; i <= _arrayList.Length; i++)
            {
                T item = _arrayList[i];
                //no puedo hacer 
                
            }
            return default;

        }

        public void SetElementAt(int index, T element)
        {
            if (index > 0 || index >= _arrayList.Length)
                return;
            for(int i = 0; i <= _arrayList.Length; i++)
            {
                
            }

        }

        public void Add(T element)
        {
            //si el elemento es nulo no deberia haber problema
            Array newArray = new Array[_arrayList.Length + 1];
            
            foreach(var e in _arrayList)
            {
                newArray = _arrayList;
                element = _arrayList[_arrayList.Length + 1];
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < _arrayList.Length; i++)
            {
                if (_arrayList.Contains<T>(element))
                    return i;
            }
            return -1;
        }

        public bool Contains(T element)
        {
            throw new Exception();

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _arrayList.Length)
                return;
            for (int i = 0; i <= _arrayList.Length; i++)
            {
                
            }
        }

        public void VisitElement(Visit<T> elements)
        {
            foreach(var c in _arrayList)
            {
                
            }
        }

        public T[] ToArray(List<T> lista)
        {
            T[] newArray = new T[_arrayList.Length];

            for(int i = 0; i <= _arrayList.Length; i++)
            {
                lista[i] = newArray[i];
            }
            return newArray;
        }

        public void Clear()
        {
            _arrayList = default;
        }

        public List<T> Filter(FilterDelegate<T> filter)
        {
            List<T> listafiltro = new List<T>();

            return listafiltro;
        }
    }
}
