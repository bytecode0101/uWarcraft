using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class Farm : Units.AbstractBuilding, IBuilding
    {
        public event BuildingComplete BuildingComplete;

        public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        public bool Complete { get; set; }

        public Farm(Game.Point location)
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            BuildBuildingsCapabilities.Add(new BuildBarrackCapability());
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