using System;
using System.Collections.Generic;
using Uwarcraft.Buildings.Interfaces;

namespace Uwarcraft.Units
{
    public class Tower : AbstractBuilding
    {
        public override event BuildingComplete BuildingComplete;

        //public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        //public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        //public bool Complete { get; set; }

        public Tower(Game.Point location)
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            Complete = false;
            Life = 75;
            Location = location;
            Type = "Tower";
        }

        public override void StartBuilding()
        {
            if (BuildingComplete != null)
            {

                BuildingComplete.Invoke();
            };
        }
    }
}
