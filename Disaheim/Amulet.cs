using Disaheim;
using System.Reflection.Emit;

public class Amulet : Merchandise
{
    public Level Quality { get; set; } = Level.Medium;
    public string Design { get; set; } = "";

    public Amulet(string itemID) : base(itemID) { }

    public Amulet(string itemID, Level quality) : base(itemID)
    {
        Quality = quality;
    }

    public Amulet(string itemID, Level quality, string design) : base(itemID)
    {
        Quality = quality;
        Design = design;
    }

    public double GetValue()
    {
        return Quality switch
        {
            Level.Low => 12.5,
            Level.Medium => 20.0,
            Level.High => 27.5,
            _ => 0.0
        };
    }

    public override string ToString()
    {
        return $"ItemId: {ItemID}, Quality: {Quality}, Design: {Design}";
    }
}