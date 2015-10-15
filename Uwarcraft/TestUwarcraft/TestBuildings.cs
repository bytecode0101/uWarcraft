using NUnit.Framework;
using Uwarcraft;
using Uwarcraft.Buildings;

using Uwarcraft.Game;
using Uwarcraft.Units;

namespace TestUwarcraft
{
    [TestFixture]
    public class TestBuildings
    {
        [Test]
        public void TestFarm()
        {
            Point xy = new Point(y:12);
            Uwarcraft.Buildings.Interfaces.AbstractBuilding farm = new Uwarcraft.Buildings.BasicBuildings.Farm(xy,60);
            farm.TakeHit(14);
            Assert.AreEqual(17,farm.Location.x);
            Assert.AreEqual(12, farm.Location.y);
            Assert.AreEqual(46, farm.Life);
        }

        PlayerBase playerBase;
        Uwarcraft.Units.IBuilding farm;
        [Test]
        
        public void TestBuildFarmCapability()
        {
            playerBase = new PlayerBase();
            IUnit p = new Peasant();
            farm = new Farm();
            farm.BuildingComplete += Farm_BuildingComplete;
            farm.StartBuilding();
            Assert.IsTrue(playerBase.BuildingsCapabilities[1] is BuildBarrackCapability);
        }

        private void Farm_BuildingComplete()
        {
            playerBase.BuildingsCapabilities.Add(farm.BuildBuildingsCapabilities[0]);

        }
    }
}
