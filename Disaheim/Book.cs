using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Book : Merchandise
    {
       
        public string Title { get; set; }   
        public double Price { get; set; }
        public override string ToString() => $"ItemId: {ItemId}, Title: {Title}, Price: {Price}";
     
        public Book(string itemId, string title, double price) : base(itemId)
        {
            ItemId = itemId;
            Title = title;
            Price = price;
        }
        public Book(string itemId, string title) : this(itemId, title, 0) { } 
        public Book(string itemId) : this(itemId, "", 0){}
    }
}
