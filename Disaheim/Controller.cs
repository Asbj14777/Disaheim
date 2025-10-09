using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Controller
    {
        public readonly List<Book> Books = new();

        public readonly List<Amulet> Amulets = new();

        public void AddToList(Book book) => Books.Add(book);  

        public void AddToList(Amulet amulet) => Amulets.Add(amulet);
    }
}




