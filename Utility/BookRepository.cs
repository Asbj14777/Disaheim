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
        private Controller Controller { get; set; } = new Controller();  
        public void AddBook(Controller controller, Book book) => controller.AddToList(book);    

        public Book GetBook(string itemId) =>  Controller.Books.FirstOrDefault(b => b.ItemId == itemId);

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var book in Controller.Books)    
                total += book.Price;
            return total;
        }   
    }
}
