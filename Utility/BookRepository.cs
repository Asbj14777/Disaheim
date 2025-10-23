using Disaheim;

namespace Utility
{
    public class BookRepository : MerchandiseRepository<Book>
    {
        public double GetTotalValue() => GetTotalValue(b => b.Price);
    }
}
