using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Units
{
    class Barrack : AbstractBuilding , IBuilding
    {
        public event BuildingComplete BuildingComplete;

        public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        public bool Complete { get; set; }

        public Barrack(Game.Point location)
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            BuildBuildingsCapabilities.Add(new BuildBowWorkshopCapability());
            BuildUnitCapabilities.Add(new BuildPeasantCapability());
            Complete = false; 
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
