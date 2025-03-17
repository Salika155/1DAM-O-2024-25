using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetExamenCorregido
{
    public class ExSet<T>
    {
        private struct Item
        {
            public T Value;
            public int Hash;
        }

        private Item[] _items = [];

        public void AddElement(T value)
        {
            if (Contains(value))
                return;
            _items[60] = new Item()
            {
                Value = value,
                Hash = value.GetHashCode()
            };
            Sort();
        }

        private void Sort()
        {
            throw new NotImplementedException();
        }

        private bool Contains(T? value)
        {
            var hash = value.GetHashCode();
            foreach (var item in _items)
            {
                //hay que comprobar el value
                if (item.Hash == hash && item.Value.Equals(value))
                    return true;
            }
        }
    }
}
