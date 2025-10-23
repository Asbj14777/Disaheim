using Disaheim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class AmuletRepository
    {
        public readonly List<Amulet> Amulets = new();

        public void AddToList(Amulet amulet) => Amulets.Add(amulet);
        public void AddAmulet(Amulet amulet) => AddToList(amulet);

        public Amulet GetAmulet(string itemId) => Amulets.FirstOrDefault(b => b.ItemId == itemId);

        public double GetTotalValue()
        {
            double total = 0;
            foreach (var amulet in Amulets)
                total += UtilityLib.Utility.GetValueOfAmulet(amulet);
            return total;
        }
    }
}
