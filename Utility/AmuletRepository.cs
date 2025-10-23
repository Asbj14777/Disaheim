using Disaheim;

namespace Utility
{
    public class AmuletRepository : MerchandiseRepository<Amulet>
    {
        public double GetTotalValue() => GetTotalValue(a => UtilityLib.Utility.GetValueOfAmulet(a));
    }
}
