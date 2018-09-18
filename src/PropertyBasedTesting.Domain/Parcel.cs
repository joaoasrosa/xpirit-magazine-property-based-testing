using System.Collections.Generic;
using System.Linq;

namespace PropertyBasedTesting.Domain
{
    public class Parcel
    {
        private readonly IEnumerable<Item> _items;
        public double TotalPrice => _items.Sum(x => x.Price);

        // For the example, we are omitting other properties

        public Parcel(IEnumerable<Item> items)
        {
            _items = items;
        }
    }
}