using Disaheim;
using System.Collections.Generic;

namespace Utility
{
    public class CourseRepository : MerchandiseRepository<Course>
    {
        public double GetTotalValue() => GetTotalValue(c => UtilityLib.Utility.GetValueOfCourse(c));
        
    }
}
