namespace Disaheim
{
    public enum Level { Low, Medium, High }
    public class Merchandise
    {
        public string ItemID { get; set; }

        public Merchandise() { }

        public Merchandise(string itemID)
        {
            ItemID = itemID;
        }
    }
}