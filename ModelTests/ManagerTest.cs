using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSSU_CIS310_MVC;
using MSSU_CIS310_MVC.model;

namespace ModelTests
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void ContainsConstructor()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Assert.IsNotNull(m, "Manager object not created");
        }

        [TestMethod]
        public void ContainsPlayerIDInstanceVariable()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Type t = typeof(Manager);

            FieldInfo fi = t.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(fi, "id instance variable not created or not private");
        }

        [TestMethod]
        public void ContainsPlayerIDProperty()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Assert.AreEqual("wrighha01", m.Id, "Id property not implemented correctly");
        }

        [TestMethod]
        public void ContainsFirstNameInstanceVariable()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Type t = typeof(Manager);

            FieldInfo fi = t.GetField("firstName", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(fi, "firstName instance variable not created or not private");
        }

        [TestMethod]
        public void ContainsFirstNameProperty()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Assert.AreEqual("Harry", m.FirstName, "FirstName property not implemented correctly");
        }


        [TestMethod]
        public void ContainsLastNameInstanceVariable()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Type t = typeof(Manager);

            FieldInfo fi = t.GetField("lastName", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(fi, "lastName instance variable not created or not private");
        }

        [TestMethod]
        public void ContainsLastNameProperty()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Assert.AreEqual("Wright", m.LastName, "LastName property not implemented correctly");
        }


        [TestMethod]
        public void ContainsWinningPercentageInstanceVariable()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 10);
            Type t = typeof(Manager);

            FieldInfo fi = t.GetField("winningPercentage", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(fi, "winningPercentage instance variable not created or not private");
        }

        [TestMethod]
        public void ContainsWinningPercentageProperty()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 10, 10);
            Assert.AreEqual("0.500", m.WinningPercentage, "WinningPercentage property not implemented correctly");

        }

        [TestMethod]
        public void WinningPercentageNotConstant()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 60);
            Assert.AreEqual("0.250", m.WinningPercentage, "WinningPercentage property not implemented correctly");

        }

        [TestMethod]
        public void WinningPercentageHandlesDivideByZero()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 0, 0);
            Assert.AreEqual("0.000", m.WinningPercentage, "WinningPercentage property does not handle divide by zero");

        }

        [TestMethod]
        public void ToStringTest()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 10, 10);
            Assert.AreEqual("Harry Wright - Pct: 0.500".ToString(), m.ToString(), "ToString not implemented correctly - check spelling carefully!");
        }

        [TestMethod]
        public void ToStringConstantTest()
        {
            Manager m = new Manager("wrighha01", "Harry", "Wright", 20, 60);
            Assert.AreEqual("Harry Wright - Pct: 0.250".ToString(), m.ToString(), "ToString not implemented correctly - check spelling carefully!");

        }

    }
}
