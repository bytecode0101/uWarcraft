using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Uwarcraft.Units
{
    //public delegate void BuildingComplete();

    public interface IBuilding
    {
        //event BuildingComplete BuildingComplete;

        //List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        //List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        bool Complete { get; set; }
        void StartBuilding();
    }
}
