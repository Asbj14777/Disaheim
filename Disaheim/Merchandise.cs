using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Merchandise
    {
        public string ItemId { get; set; }


        public Merchandise(string itemId)
        {
            ItemId = itemId;
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}"; 
        }



    }
}
