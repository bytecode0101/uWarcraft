﻿using NUnit.Framework;
using Uwarcraft;
using Uwarcraft.Buildings;

using Uwarcraft.Game;
using Uwarcraft.Units;

namespace TestUwarcraft
{
    [TestFixture]
    public class TestBuildings
    {
        //[Test]
        //public void TestFarm()
        //{
        //    Point xy = new Point(17,12);
        //    Uwarcraft.Buildings.Interfaces.OldAbstractBuilding farm = new Uwarcraft.Buildings.BasicBuildings.Farm(xy);
        //    farm.TakeHit(14);
        //    Assert.AreEqual(17,farm.Location.x);
        //    Assert.AreEqual(12, farm.Location.y);
        //    Assert.AreEqual(86, farm.Life);
        //}

        PlayerBase playerBase;
        Uwarcraft.Units.IBuilding farm;
        [Test]
        
        public void TestBuildFarmCapability()
        {
            playerBase = new PlayerBase();            
            IUnit p = new Peasant(new Point(14,14));
            Point xy = new Point(17, 12);
            IUnit a = new Archer(new Point(13, 13));
            p.Attack(a);
            Assert.AreEqual(1,a.unitDamageSuffered);
            //farm = new Farm(xy);
            if (playerBase.BuildingsCapabilities[0] is BuildFarmCapability)
            {
                farm = playerBase.BuildingsCapabilities[0].Build(xy);
            }            
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
