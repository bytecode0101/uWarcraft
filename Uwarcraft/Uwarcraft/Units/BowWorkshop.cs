using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BowWorkshop : Units.AbstractBuilding, IBuilding
    {
        public event BuildingComplete BuildingComplete;

        public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }

        public BowWorkshop(Game.Point location)
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            //BuildBuildingsCapabilities.Add(new BuildBowWorkshopCapability());
            BuildUnitCapabilities.Add(new BuildPeasantCapability());
            Cost = 100;
            Life = 100;
            Location = location;

        }

        public void StartBuilding()
        {
            if (BuildingComplete != null)
            {

                BuildingComplete.Invoke();
            };
        }        
    }
}