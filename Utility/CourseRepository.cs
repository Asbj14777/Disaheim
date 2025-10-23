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
        public readonly List<Course> Courses = new();
        public void AddToList(Course course) => Courses.Add(course);
        public void AddCourse(Course course) => AddToList(course);

        public Course GetCourse(string itemId) => Courses.FirstOrDefault(b => b.Name == itemId);

        public double GetTotalValue()
        {
            double total = 0;
            foreach (var course in Courses)
                total += UtilityLib.Utility.GetValueOfCourse(course);
            return total;
        }
    }
}
