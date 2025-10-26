using Disaheim;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Utility
{
    public class ValuableRepository
    {
        private readonly List<object> _items = new();

        public void AddValuable(object item) => _items.Add(item);

        public object GetValuable(string itemId)
        {
            return _items.FirstOrDefault(item =>
                (item is Merchandise m && m.ItemID == itemId) ||
                (item is Course c && c.CourseName == itemId));
        }
        public int Count() => _items.Count;

        public double GetTotalValue()
        {
            double total = 0.0;
            foreach (var item in _items)
            {
                switch (item)
                {
                    case Book b: total += b.GetValue(); break;
                    case Amulet a: total += a.GetValue(); break;
                    case Course c: total += c.GetValue(); break;
                }
            }
            return total;
        }

        public void Save(string filename = "ValuableRepository.txt")
        {
            using (StreamWriter writer = new StreamWriter(filename, append: false))
            {
                foreach (var item in _items)
                {
                    switch (item)
                    {
                        case Book b:
                            writer.WriteLine($"BOG;{b.ItemID};{b.Title};{b.GetValue()}");
                            break;
                        case Amulet a:
                            writer.WriteLine($"AMULET;{a.ItemID};{a.Quality};{a.Design}");
                            break;
                        case Course c:
                            writer.WriteLine($"KURSUS;{c.CourseName};{c.DurationInMinutes}");
                            break;
                    }
                }
            }
        }

        public void Load(string filename = "ValuableRepository.txt")
        {

            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "BOG":
                        _items.Add(new Book(parts[1], parts[2], double.Parse(parts[3])));
                        break;

                    case "AMULET":
                        Level level = parts.Length > 2 ? Enum.Parse<Level>(parts[2]) : Level.Medium;
                        string design = parts.Length > 3 ? parts[3] : "";
                        _items.Add(new Amulet(parts[1], level, design));
                        break;

                    case "KURSUS":
                        string name = parts[1];
                        int duration = parts.Length > 2 ? int.Parse(parts[2]) : 0;
                        _items.Add(new Course(name, duration));
                        break;
                }
            }
        }
    }
}
