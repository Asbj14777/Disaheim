using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Utility
    {
        public double GetValueOfBook(Book book) => book.Price;

        public double GetValueOfAmulet(Amulet amulet)
        {
            double value = amulet.Quality switch
            {
                Amulet.Level.low => 12.5,
                Amulet.Level.medium => 20.0,
                Amulet.Level.high => 27.5,
                _ => 0.0
            };
            return value; 
        }


    }
}
