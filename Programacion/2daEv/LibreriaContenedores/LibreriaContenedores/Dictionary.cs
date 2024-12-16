using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaContenedores
{
    public class Dictionary<K, V>
    {
        private class Item
        {
            public K? Key;
            public V? Value;

            public Item(K? key, V? value)
            {
                Key = key;
                Value = value;
            }
        }

        private List<Item> _itemList;

        public Dictionary()
        {
            _itemList = new List<Item>();
        }

        public int Count => _itemList.Count;
        public bool Empty => _itemList.Count == 0;


        public void Add(K? key, V? value)
        {
            if (key == null && value == null)
                return;

            _itemList.Add(new Item(key, value));
        }

        //indexofkey
        public int IndexOfKey(K? key)
        {
            if (key == null)
                return -1;

            for (int i = 0; i < _itemList.Count; i++)
            {
                var keyvalue = _itemList[i].Key;
                if (AreEquals(keyvalue, key))
                    return i;
            }
            return -1;
        }

        //containskey
        public bool ContainsKey(K? key)
        {
            return IndexOfKey(key) != -1;
        }

        //void clear
        public void Clear()
        {
            _itemList = new List<Item>();
        }

        //void addorreplace
        public void AddOrReplace(K? key, V? value)
        {
            if (key == null)
                return;

            int index = IndexOfKey(key);
            //sin index distinto de -1 quiere decir que existe
            if (index != -1)
            {
                _itemList[index].Value = value;
            }
            else
            {
                Add(key, value);
            }
        }

        //removekey
        public void RemoveKey(K? key)
        {
            if (key == null)
                return;

            int index = IndexOfKey(key);
            for (int i = 0; i < _itemList.Count; i++)
            {
                if (index != -1)
                {
                    _itemList.RemoveAt(index);
                    i--;
                }
            }
        }

        //getvaluewithkey
        public V? GetValueWithKey(K? key)
        {
            if (key == null)
                return default;

            for (int i = 0; i < _itemList.Count; i++)
            {
                if (AreEquals(key, _itemList[i].Key))
                {
                    return _itemList[i].Value;
                }
            }
            return default(V);
        }

        //trygetvalue
        public bool TryGetValue(K? key, out V? value)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                if (AreEquals(_itemList[i].Key, key))
                {
                    value = _itemList[i].Value;
                    return true;
                }
            }
            value = default(V);
            return false;
        }

        // Comparar manualmente las claves
        private static bool AreEquals(K? a, K? b)
        {
            if (ReferenceEquals(a, b)) // Mismo objeto
                return true;
            if (a == null || b == null) // Uno es nulo
                return false;

            // Comparación genérica: esto depende del tipo K.
            return a.ToString() == b.ToString(); // Usar propiedades únicas del tipo K si no puedes usar ToString
        }
    }
}
