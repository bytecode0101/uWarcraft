using NUnit.Framework;
using Uwarcraft.Buildings;
using Uwarcraft.Buildings.BasicBuildings;
using Uwarcraft.Buildings.Interfaces;
using Uwarcraft.Game;

namespace TestUwarcraft
{
    [TestFixture]
    public class TestBuildings
    {
        [Test]
        public void TestFarm()
        {
            Point xy = new Point(y:12);
            AbstractBuilding farm = new Farm(xy,60);
            farm.TakeHit(14);
            Assert.AreEqual(17,farm.Location.x);
            Assert.AreEqual(12, farm.Location.y);
            Assert.AreEqual(46, farm.Life);
        }
    }
}
