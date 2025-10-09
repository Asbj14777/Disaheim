using Disaheim;
using System; 
class Program
{
    static void Main(string[] args)
    {
        Book book = new Book("001", "The Great Adventure", 19.99);
        Amulet amulet = new Amulet("A001", Level.High, "Dragon Design");
        System.Console.WriteLine($"{book}");
        System.Console.WriteLine($"{amulet}"); 
        Console.ReadKey();
    }
}