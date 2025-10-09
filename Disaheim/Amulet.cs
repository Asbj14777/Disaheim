﻿using System;
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
    public class Amulet
    {
    
        public string ItemId { get; private set; }  
        public string Design { get; private set; }
        public Level Quality { get; private set; }

        public Amulet(string itemId, Level quality, string design)
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
