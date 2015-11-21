using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BowWorkshop : AbstractBuilding
    {
        public override event BuildingComplete BuildingComplete;
        public override event EventHandler Destroyed;

        //public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        //public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        //public bool Complete { get; set; }

        public BowWorkshop(Game.Point location)
        {
            //BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            //BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            //BuildBuildingsCapabilities.Add(new BuildTowerCapability());
            //BuildUnitCapabilities.Add(new BuildArcherCapability());
            Complete = false;
            Life = 100;
            Position = location;
            Type = "BowWorkshop";
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