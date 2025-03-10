using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public class Dictionary<K, V>
    {
        // Delegado para la acción que se ejecutará en el método Visitor
        public delegate void VisitorAction(K key, V value);

        // Delegado para la función de filtro
        public delegate bool FilterPredicate(K key, V value);

        private class DictionaryItem
        {
            public K Key;
            public V Value;

            public DictionaryItem(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        private List<DictionaryItem> _itemList;

        public Dictionary()
        {
            _itemList = new List<DictionaryItem>();
        }

        public int Count => _itemList.Count;
        public bool Empty => _itemList.Count == 0;

        // Añadir un elemento si la clave no existe
        public void Add(K key, V value)
        {
            // Comprobación de que la clave no sea null
            if (key == null)
                return;

            if (!ContainsKey(key))
            {
                _itemList.Add(new DictionaryItem(key, value));
            }
        }

        // Obtener el índice de una clave
        public int IndexOfKey(K key)
        {
            // Comprobación de que la clave no sea null
            if (key == null)
                return -1;

            for (int i = 0; i < _itemList.Count; i++)
            {
                var keyitem = _itemList[i].Key;
                if (Equals(keyitem, key))
                    return i;
            }
            return -1;
        }

        // Verificar si una clave existe
        public bool ContainsKey(K key) => key != null && IndexOfKey(key) != -1;

        // Verificar si un valor existe
        public bool ContainsValue(V value)
        {
            // Comprobación de que el valor no sea null
            if (value == null)
                return false;

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
            // Sin necesidad de comprobación aquí, ya que la lista simplemente se limpia
            _itemList.Clear();
        }

        // Agregar o reemplazar un valor para una clave dada
        public void AddOrReplace(K key, V value)
        {
            // Comprobación de que la clave no sea null
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
        public void RemoveKey(K key)
        {
            // Comprobación de que la clave no sea null
            if (key == null)
                return;

            int index = IndexOfKey(key);
            if (index != -1)
            {
                _itemList.RemoveAt(index);
            }
        }

        // Obtener el valor asociado a una clave
        public V? GetValueWithKey(K key)
        {
            // Comprobación de que la clave no sea null
            if (key == null)
                return default;

            int index = IndexOfKey(key);
            return index != -1 ? _itemList[index].Value : default;
        }

        // Intentar obtener un valor con una clave
        public bool TryGetValue(K key, out V? value)
        {
            // Comprobación de que la clave no sea null
            if (key == null)
            {
                value = default;
                return false;
            }

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
            get
            {
                // Comprobación de que la clave no sea null
                if (key == null)
                    return default;

                return GetValueWithKey(key);
            }
            set
            {
                // Comprobación de que la clave no sea null y el valor no sea null
                if (key != null)
                {
                    // Si value es null, puedes decidir qué hacer, por ejemplo, no hacer nada:
                    if (value != null)
                    {
                        AddOrReplace(key, value);
                    }
                    else
                    {
                        // Si deseas hacer algo con value null, como eliminar la clave, descomenta la siguiente línea:
                        // RemoveKey(key);
                    }
                }
            }
        }

        // **Método Visitor** para recorrer los elementos y ejecutar una acción
        public void Visitor(VisitorAction action)
        {
            // Si la acción es null, no hacemos nada
            if (action == null)
                return;
            //foreach (var item in _itemList)
            //{
            //    // Comprobación de que key y value no sean null
            //    if (item.Key != null && item.Value != null)
            //    {
            //        action(item.Key, item.Value);
            //    }
            //}

            for (int i = 0; i < _itemList.Count; i++)
            {
                // Comprobación de que key y value no sean null
                if (_itemList[i].Key != null && _itemList[i].Value != null)
                {
                    action(_itemList[i].Key, _itemList[i].Value);
                }
            }
        }

        // **Método Filter** para obtener elementos que cumplan una condición
        public Dictionary<K, V> Filter(FilterPredicate predicate)
        {
            // Si el predicado es null, devolvemos un diccionario vacío
            if (predicate == null)
                return new Dictionary<K, V>();

            Dictionary<K, V> result = new Dictionary<K, V>();

            for (int i = 0; i < _itemList.Count; i++)
            {
                // Comprobación de que key y value no sean null
                if (_itemList[i].Key != null && _itemList[i].Value != null &&
                    predicate(_itemList[i].Key, _itemList[i].Value))
                {
                    result.Add(_itemList[i].Key, _itemList[i].Value);
                }
            }

            //foreach(var item in _itemList)
            //{
            //    if (item.Key != null && item.Value != null &&
            //        predicate(item.Key, item.Value))
            //    {
            //        result.Add(item.Key, item.Value);
            //    }
            //}

            return result;
        }
    }
}