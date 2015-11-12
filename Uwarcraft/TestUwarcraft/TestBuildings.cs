using NUnit.Framework;
using System;
using Uwarcraft;
using Uwarcraft.Buildings;

using Uwarcraft.Game;
using Uwarcraft.Game.StateMachine;
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

        //PlayerBase playerBase;
        //AbstractBuilding farm;
        public event EventHandler<BuildCommandEventArgs> BuildCommand;
        [Test]
        public void TestBuildings1()
        {
            Game g = new Game(new PlayState());
            var st = (PlayState)g.CurrentState;
            var buildings = st.PlayerBase.Buildings;
            var units = st.PlayerBase.Units;
            BuildCommand += st.OnBuildCommand;
            OnBuildCommand("Farm", new Point(11, 16));
            Assert.AreEqual(st.PlayerBase.Buildings.Count, 1);
            OnBuildCommand("Tower", new Point(18, 9));
            Assert.AreEqual(st.PlayerBase.Buildings.Count, 1);
            OnBuildCommand("BowWorkshop", new Point(14, 13));
            Assert.AreEqual(st.PlayerBase.CountBuildings["Farm"], 1);
            Assert.AreEqual(st.PlayerBase.CountBuildings["BowWorkshop"], 0);
            OnBuildCommand("Barrack", new Point(10, 17));
            Assert.AreEqual(st.PlayerBase.CountBuildings["Barrack"], 1);
            Assert.AreEqual(st.PlayerBase.Buildings.Count, 2);
            Assert.AreEqual(st.PlayerBase.Buildings[1].Location.y,17);
        }



        public void OnBuildCommand(string type, Point coords)
        {
            if (BuildCommand!=null)
            {
                BuildCommandEventArgs e = new BuildCommandEventArgs() { Coords = coords, Type = type };
                BuildCommand(this, e);
            }
        }
        //public void TestBuildFarmCapability()
        //{
        //    playerBase = new PlayerBase();
        //    IUnit p = new Peasant(new Point(14, 14));
        //    //Point xy = new Point(17, 12);
        //    IUnit a = new Archer(new Point(13, 13));
        //    for (int i = 0; i < 6; i++)
        //    {
        //        p.Attack(a);
        //        a.Attack(p);
        //    }

        //    Assert.AreEqual(5, a.unitDamageSuffered);
        //    //farm = new Farm(xy);
        //    if (playerBase.BuildingsCapabilities[0] is BuildFarmCapability)
        //    {
        //        farm.BuildingComplete += Farm_BuildingComplete;
        //        farm.StartBuilding();

        //    }

        //    Assert.IsTrue(playerBase.BuildingsCapabilities[1] is BuildBarrackCapability);
        //}

        //private void Farm_BuildingComplete()
        //{
        //    playerBase.BuildingsCapabilities.Add(farm.BuildBuildingsCapabilities[0]);
        //    farm = playerBase.BuildingsCapabilities[0].Build(new Point(17, 12));
        //}
    }
}
