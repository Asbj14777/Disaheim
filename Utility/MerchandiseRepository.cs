using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility
{
    public class MerchandiseRepository<T> where T : Disaheim.Merchandise
    {
        private readonly List<T> _items = new();
        public void AddMerchandise(T item) => _items.Add(item);

        public T GetMerchandise(string itemId) => _items.FirstOrDefault(i => i.ItemId == itemId);

        public double GetTotalValue(Func<T, double> valueSelector) => _items.Sum(valueSelector);
    }
}
