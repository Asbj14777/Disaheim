using Disaheim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace UtilityLib
{ 
    public class Utility
    {
        public double GetValueOfBook(Book book) => book.Price;

        public static double GetValueOfAmulet(Amulet amulet)
        {
            double value = amulet.Quality switch
            {
                Level.Low => Amulet.low,
                Level.Medium => Amulet.medium,
                Level.High => Amulet.high,
                _ => 0.0
            };
            return value;
        }
        public static double GetValueOfCourse(Course course)
        {
            double value = 0.0;
            for (int i = 0; i < course.DurationInMinutes; i += 60)
                value = value + 875.00;
            return value;

        }
    }
}