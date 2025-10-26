using Disaheim;

public class Book : Merchandise
{
    public string Title { get; set; } = "";
    public double Price { get; set; }

    public Book(string itemID) : base(itemID) { }

    public Book(string itemID, string title) : base(itemID)
    {
        Title = title;
    }

    public Book(string itemID, string title, double price) : base(itemID)
    {
        Title = title;
        Price = price;
    }

    public double GetValue() => Price;

    public override string ToString()
    {
        return $"ItemId: {ItemID}, Title: {Title}, Price: {Price}";
    }
}