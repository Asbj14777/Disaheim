using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public enum Level
    {
        Low,
        Medium,
        High
    }
    public class Amulet : Merchandise
    {
        public string Design { get; set; }
        public Level Quality { get; set; }

        public static double low { get; set; } = 12.5;
        public static  double medium { get; set; } = 20.0; 
        public static double high { get; set; } = 27.5;

        public Amulet(string itemId, Level quality, string design) : base(itemId)
        {
            ItemId = itemId;
            Design = design;
            Quality = quality; 
        }   
        public Amulet(string itemId, Level quality) : this(itemId, Level.High, "") { }
        public Amulet(string itemId) : this(itemId, Level.Medium, "") { }
        public override string ToString() => $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}"; 
     
    }
}
