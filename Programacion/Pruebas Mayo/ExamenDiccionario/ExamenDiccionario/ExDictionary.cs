using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDiccionario
{
    class ExDictionary<TKey, TValue>
    {
        public delegate void VisitDelegate(TKey key, TValue value);
        public delegate bool FilterDelegate(TKey key, TValue value);
        private class Item
        {
            public TKey Key { get; }
            public TValue Value { get; set; }

            public Item(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private Item[] _items;
        private int _count;

        public ExDictionary()
        {
            _items = new Item[0];
            _count = 0;
        }

        public ExDictionary(TKey[] key, TValue[] value)
        {
            if (key == null || value == null)
                throw new Exception();
            if (key.Length != value.Length)
                throw new Exception();
            _items = new Item[key.Length];
            _count = 0;
            for(int i = 0; i < key.Length; i++)
            {
                Add(_items[i].Key, _items[i].Value);
            }
        }

        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                return;
            if (Contains(key))
                throw new InvalidOperationException("La clave ya existe.");
            ResizeArray();
            _items[_count++] = new Item(key, value);
        }

        private void ResizeArray()
        {
            if (_items.Length == _count)
            {
                int nuevoTamaño = _items.Length == 0 ? 4 : _items.Length * 2;
                Item[] newArray = new Item[nuevoTamaño];
                for(int i = 0; i < _count; i++)
                {
                    newArray[i] = _items[i];
                }
                _items = newArray;
            }
        }

        public bool Remove(TKey key)
        {
            int index = IndexOf(key);
            if (index == -1)
                return false;

            for (int i = index; i < _count -1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            _items[_count] = null;
            return true;
        }

        public bool Contains(TKey key)
        {
            return IndexOf(key) >= 0;
        }

        public int IndexOf(TKey key)
        {
            for(int i = 0; i < _count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(_items[i].Key, key))
                    return i;
            }
            return -1;
        }

        public TValue? GetValue(TKey key)
        {
            for(int i = 0; i < _count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(_items[i].Key, key))
                    return _items[i].Value;
            }
            return default;
        }

        public void Clear()
        {
            //for(int i = 0; i < _count; i++)
            //{
            //     _items[i] = null;
            //}
            // _count = 0;
            _items = new Item[0];
            _count = 0;
        }

        public void Visit(VisitDelegate del)
        {
            for(int i = 0; i < _count; i++)
            {
                del(_items[i].Key, _items[i].Value);
            }
        }

        public ExDictionary<TKey, TValue> Filter(FilterDelegate del)
        {
            var result = new ExDictionary<TKey, TValue>();

            for(int i = 0; i < _count; i++)
            {
                var entry = _items[i];
                if(del(entry.Key, entry.Value))
                {
                    result.Add(entry.Key, entry.Value);
                }  
            }
            return result;
        }

        public ExDictionary<TValue, TKey> Reversed
        {
            get
            {
                var result = new ExDictionary<TValue, TKey>();

                for (int i = 0; i < _count; i++)
                {
                    var entry = _items[i];

                    if (!result.Contains(entry.Value))
                    {
                        result.Add(entry.Value, entry.Key);
                    }
                }
                return result;
            }
        }

        public ExDictionary<TKey, TValue> Clone()
        {
            var result = new ExDictionary<TKey, TValue>();

            for(int i = 0; i < _count; i++)
            {
                var entradaKey = _items[i].Key;
                var entradaValue = _items[i].Value;
                var entrada = _items[i];

                if(!result.Contains(entradaKey))
                {
                    result.Add(entradaKey, entradaValue);
                }
            }
            return result;
        }

        //(E) Aparte de los que quieras,
        //un constructor que acepte dos arrays, uno de keys y otro de values. El diccionario
        //se creará con esa información donde la key que está en la posición 0 se relaciona
        //con el value que está en la posición 0 y así sucesivamente

        //"Este método promete que va a asignar un valor a value antes de salir, por eso el default."
        public bool TryGetValue(TKey key, out TValue? value)
        {
            for(int i = 0; i < _count; i++)
            {
                var entrada = _items[i];
                if (EqualityComparer<TKey>.Default.Equals(entrada.Key, key))
                {
                    value = entrada.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        public (TKey, TValue)[] ToArray()
        {
            var result = new (TKey, TValue)[_count];

            for(int i = 0; i < _count; i++)
            {
                var entrada = _items[i];
                result[i] = (entrada.Key, entrada.Value);
            }
            return result;
        }
    }
}
