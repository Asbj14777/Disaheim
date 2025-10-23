using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Course : Merchandise
    {
        public string Name { get; set; }    
        public int DurationInMinutes { get; set; }  

        public Course(string name, int durationInMinutes) : base(name) 
        {
            Name = name;
            DurationInMinutes = durationInMinutes;
        }
        public Course(string name) : this(name, 0) { } 
        public override string ToString() => $"Name: {Name}, Duration in Minutes: {DurationInMinutes}";   
    }
}
