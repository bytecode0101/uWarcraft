using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class Farm : Units.IBuilding
    {
        public List<AbstractBuildUnitCapability> BuildUnitCapabilities
        {
            get; set;
        }

        public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities
        {
            get; set;
        }

        public event BuildingComplete BuildingComplete;

        public Farm()
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            BuildBuildingsCapabilities.Add(new BuildBarrackCapability());

            
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