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
        private Controller Controller { get; set; } = new Controller();
        public void AddAmulet(Controller controller, Amulet amulet) => controller.AddToList(amulet);

        public Amulet GetAmulet(string itemId) => Controller.Amulets.FirstOrDefault(b => b.ItemId == itemId);

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var amulet in Controller.Amulets)
                total += UtilityLib.Utility.GetValueOfAmulet(amulet);
            return total;
        }
    }
}
