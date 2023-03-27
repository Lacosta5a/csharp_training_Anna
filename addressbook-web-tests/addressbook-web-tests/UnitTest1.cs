using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1. Size, 5);
            Assert.AreEqual(s2.Size, 10); 
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;

            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;
            Assert.AreEqual(s2.Colored, true);

        }
        [TestMethod]
        public void TestMethodCircle()
        {
            Circle1 s1 = new Circle1 (5);
            Circle1 s2 = new Circle1(10);
            Circle1 s3 = s1;

            Assert.AreEqual(s1.Radius, 5);
            Assert.AreEqual(s2.Radius, 10);
            Assert.AreEqual(s3.Radius, 5);

            s3.Radius = 15;

            Assert.AreEqual(s1.Radius, 15);

            s2.Colored = true;
            Assert.AreEqual(s2.Colored, true);

        }
    }
}
