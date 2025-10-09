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
                Level.Low       =>    12.5,
                Level.Medium    =>    20.0,
                Level.High      =>    27.5,
                /*ingen*/     _ =>    0.0
            };
            return value; 
        }


    }
}
