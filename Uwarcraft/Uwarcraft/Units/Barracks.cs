using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Units
{
    class Barrack : AbstractBuilding 
    {
        public override event BuildingComplete BuildingComplete;
        public override event EventHandler Destroyed;
        

        public Barrack(Game.Point location)
        {
            //BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            //BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            //BuildBuildingsCapabilities.Add(new BuildBowWorkshopCapability());
            //BuildUnitCapabilities.Add(new BuildPeasantCapability());
            Complete = false; 
            Life = 100;
            Position = location;
            Type = "Barrack";
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
