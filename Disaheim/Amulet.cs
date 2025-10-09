using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Amulet
    {
        public enum Level
        {
            low,
            medium,
            high
        }
        public string ItemId { get; set; }  
        public string Design { get; set; }
        Level Quality { get; set; }

        public Amulet(string itemId, Level quality, string design)
        {
            ItemId = itemId;
            Design = design;
            Quality = quality;
        }   
        public Amulet(string itemId, Level quality) : this(itemId, Level.high, "") { }
        public Amulet(string itemId) : this(itemId, Level.medium, "") { }
        public override string ToString() => $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}"; 
     
    }
}
