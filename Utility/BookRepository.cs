using Disaheim; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Utility
{
    public class BookRepository
    {
            
        public readonly List<Book> Books = new();
        public void AddToList(Book book) => Books.Add(book);
        public void AddBook(Book book) => AddToList(book);    

        public Book GetBook(string itemId) =>  Books.FirstOrDefault(b => b.ItemId == itemId);

        public double GetTotalValue()
        {
            double total = 0;
            foreach (var book in Books)    
                total += book.Price;
            return total;
        }   
    }
}
