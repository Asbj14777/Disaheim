using Disaheim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class CourseRepository
    {
        private Controller Controller { get; set; } = new Controller();
        public void AddCourse(Controller controller, Course course) => controller.AddToList(course);

        public Course GetCourse(string itemId) => Controller.Courses.FirstOrDefault(b => b.ItemId == itemId);

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var course in Controller.Courses)
                total += UtilityLib.Utility.GetValueOfCourse(course);
            return total;
        }
    }
}
