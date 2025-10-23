using Disaheim;
using Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest4
{
    Merchandise c1, c2, b1, b2, b3, a1, a2, a3;

    MerchandiseRepository<Book> bookRepo;
    MerchandiseRepository<Amulet> amuletRepo;
    MerchandiseRepository<Course> courseRepo;

    [TestInitialize]
    public void Init()
    {
        // Arrange — create items
        // Books
        b1 = new Book("1", "Unknown Book", 0.0);
        b2 = new Book("2", "Falling in Love with Yourself", 0.0);
        b3 = new Book("3", "Spirits in the Night", 123.55);

        // Amulets
        a1 = new Amulet("11");
        a2 = new Amulet("12", Level.High);
        a3 = new Amulet("13", Level.Low, "Capricorn");

        // Courses
        c1 = new Course("Eufori med røg");
        c2 = new Course("Nuru Massage using Chia Oil", 157);

        // Create repositories
        bookRepo = new MerchandiseRepository<Book>();
        amuletRepo = new MerchandiseRepository<Amulet>();
        courseRepo = new MerchandiseRepository<Course>();

        // Act — add all items to the correct repository
        bookRepo.AddMerchandise((Book)b1);
        bookRepo.AddMerchandise((Book)b2);
        bookRepo.AddMerchandise((Book)b3);

        amuletRepo.AddMerchandise((Amulet)a1);
        amuletRepo.AddMerchandise((Amulet)a2);
        amuletRepo.AddMerchandise((Amulet)a3);

        courseRepo.AddMerchandise((Course)c1);
        courseRepo.AddMerchandise((Course)c2);
    }

    [TestMethod]
    public void TestGetBook()
    {
        // Assert
        Assert.AreEqual(b2, bookRepo.GetMerchandise("2"));
    }

    [TestMethod]
    public void TestGetAmulet()
    {
        // Assert
        Assert.AreEqual(a3, amuletRepo.GetMerchandise("13"));
    }

    [TestMethod]
    public void TestGetCourse()
    {
        // Assert
        Assert.AreEqual(c1, courseRepo.GetMerchandise("Eufori med røg"));
    }

    [TestMethod]
    public void TestGetTotalValueForBook()
    {
        // Assert
        double expected = 123.55;
        double actual = bookRepo.GetTotalValue(b => b.Price);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetTotalValueForAmulet()
    {
        // Assert
        double expected = 60.0;
        double actual = amuletRepo.GetTotalValue(a => UtilityLib.Utility.GetValueOfAmulet(a));
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetTotalValueForCourse()
    {
        // Assert
        double expected = 2625.0;
        double actual = courseRepo.GetTotalValue(c => UtilityLib.Utility.GetValueOfCourse(c));
        Assert.AreEqual(expected, actual);
    }
}
