using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
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

        // Añadir un elemento si la clave no existe
        public void Add(K? key, V? value)
        {
            if (key == null)
                return;

            if (!ContainsKey(key))
            {
                _itemList.Add(new Item(key, value));
            }
        }

        // Obtener el índice de una clave
        public int IndexOfKey(K? key)
        {
            if (key == null)
                return -1;

            for (int i = 0; i < _itemList.Count; i++)
            {
                if (Equals(_itemList[i].Key, key))
                    return i;
            }
            return -1;
        }

        // Verificar si una clave existe
        public bool ContainsKey(K? key) => IndexOfKey(key) != -1;

        // Verificar si un valor existe
        public bool ContainsValue(V? value)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                if (Equals(_itemList[i].Value, value))
                    return true;
            }
            return false;
        }

        // Eliminar todos los elementos sin crear una nueva lista
        public void Clear()
        {
            for (int i = _itemList.Count - 1; i >= 0; i--)
            {
                _itemList.RemoveAt(i);
            }
        }

        // Agregar o reemplazar un valor para una clave dada
        public void AddOrReplace(K? key, V? value)
        {
            if (key == null)
                return;

            int index = IndexOfKey(key);
            if (index != -1)
            {
                _itemList[index].Value = value;
            }
            else
            {
                Add(key, value);
            }
        }

        // Eliminar una clave
        public void RemoveKey(K? key)
        {
            if (key == null)
                return;

            int index = IndexOfKey(key);
            if (index != -1)
            {
                _itemList.RemoveAt(index);
            }
        }

        // Obtener el valor asociado a una clave
        public V? GetValueWithKey(K? key)
        {
            int index = IndexOfKey(key);
            return index != -1 ? _itemList[index].Value : default;
        }

        // Intentar obtener un valor con una clave
        public bool TryGetValue(K? key, out V? value)
        {
            int index = IndexOfKey(key);
            if (index != -1)
            {
                value = _itemList[index].Value;
                return true;
            }
            value = default;
            return false;
        }

        // **Indexador** para acceder a valores directamente con []
        public V? this[K key]
        {
            get => GetValueWithKey(key);
            set => AddOrReplace(key, value);
        }

        // **Método Visitor** para recorrer los elementos y ejecutar una acción
        public void Visitor(Action<K?, V?> action)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                action(_itemList[i].Key, _itemList[i].Value);
            }
        }

        // **Método Filter** para obtener elementos que cumplan una condición
        public Dictionary<K, V> Filter(Func<K?, V?, bool> predicate)
        {
            Dictionary<K, V> result = new Dictionary<K, V>();

            for (int i = 0; i < _itemList.Count; i++)
            {
                if (predicate(_itemList[i].Key, _itemList[i].Value))
                {
                    result.Add(_itemList[i].Key, _itemList[i].Value);
                }
            }
            return result;
        }
    }
}
