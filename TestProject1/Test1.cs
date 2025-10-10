using Disaheim;
using UtilityLib; 
using System.Reflection.Emit;
namespace TestProject1
{
    [TestClass]
    public class UnitTest3
    {
        Book b1, b2, b3;
        Amulet a1, a2, a3;
        Course c1, c2, c3;
        Controller controller;
            
        [TestInitialize]
        public void Init()
        {
            // Arrange

            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);

            a1 = new Amulet("11");
            a2 = new Amulet("12", Level.High);
            a3 = new Amulet("13", Level.Low, "Capricorn");

            c1 = new Course("Spådomskunst for nybegyndere");

            c2 = new Course("Magi – når videnskaben stopper", 157);

            c3 = new Course("Et indblik i Helleristning", 180);

            controller = new Controller();

            controller.AddToList(b1);
            controller.AddToList(b2);
            controller.AddToList(b3);

            controller.AddToList(a1);
            controller.AddToList(a2);
            controller.AddToList(a3);

            controller.AddToList(c1);

            controller.AddToList(c2);

            controller.AddToList(c3);
        }

        [TestMethod]
        public void TestBookList()
        {
            // Assert
            Assert.AreEqual(b3, controller.Books[2]);
        }

        [TestMethod]
        public void TestAmuletList()
        {
            // Assert
            Assert.AreEqual(a1, controller.Amulets[0]);
        }
        [TestMethod]

        public void MerchandiseConstructorWorkProperly()

        {

            // Arrange

            Merchandise m = new Merchandise("100");


            // Assert

            Assert.AreEqual("ItemId: 100", m.ToString());

        }
        [TestMethod]

        public void CourseConstructorWithOneParameter()

        {

            // Assert

            Assert.AreEqual("Name: Spådomskunst for nybegyndere, Duration in Minutes: 0", c1.ToString());

        }

        [TestMethod]

        public void CourseConstructorWithTwoParameters1()

        {

            // Assert

            Assert.AreEqual("Name: Magi – når videnskaben stopper, Duration in Minutes: 157", c2.ToString());

        }

        [TestMethod]

        public void CourseConstructorWithTwoParameters2()

        {

            // Assert

            Assert.AreEqual("Name: Et indblik i Helleristning, Duration in Minutes: 180", c3.ToString());

        }


        [TestMethod]

        public void AmuletSetPropertiesWorks()

        {

            // Act

            a3.ItemId = "X";

            a3.Quality = Level.High;

            a3.Design = "Dolphin";


            // Assert

            Assert.AreEqual("ItemId: X, Quality: High, Design: Dolphin", a3.ToString());

        }

        [TestMethod]

        public void BookSetPropertiesWorks()

        {

            // Act

            b3.ItemId = "Y";

            b3.Title = "Smoke on the Water";

            b3.Price = 376.45;


            // Assert

            Assert.AreEqual("ItemId: Y, Title: Smoke on the Water, Price: 376,45", b3.ToString());

        }

        [TestMethod]

        public void CourseSetPropertiesWorks()

        {

            // Act

            c2.Name = "How to Ying-Yang";

            c2.DurationInMinutes = 413;


            // Assert

            Assert.AreEqual("Name: How to Ying-Yang, Duration in Minutes: 413", c2.ToString());

        }
        [TestMethod]

        public void TestGetValueForCourse1()
        {

            // Assert
          
            
            Assert.AreEqual(0.0, Utility.GetValueOfCourse(c1));

        }

        [TestMethod]

        public void TestGetValueForCourse2()

        {

            // Assert

            Assert.AreEqual(2625.0, Utility.GetValueOfCourse(c2));

        }

        [TestMethod]

        public void TestGetValueForCourse3()

        {

            // Assert

            Assert.AreEqual(2625.0, Utility.GetValueOfCourse(c3));

        }

        [TestMethod]

        public void TestCourseList()

        {

            // Assert

            Assert.AreEqual(c1, controller.Courses[0]);

            Assert.AreEqual(c2, controller.Courses[1]);

            Assert.AreEqual(c3, controller.Courses[2]);

        }

    }







}
