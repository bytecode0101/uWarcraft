using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Uwarcraft.Units
{
    //public delegate void BuildingComplete();

    public abstract class AbstractBuilding
    {
        //public event BuildingComplete BuildingComplete;

        //public List<AbstractBuildUnitCapability> BuildUnitCapabilities { get; set; }
        //public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities { get; set; }
        public int Life { get; set; }
        public int DamageTaken { get; set; }
        
        public Game.Point Location { get; set; }

        public virtual void TakeHit(int attackPower)
        {
            DamageTaken += attackPower;
        }

        //public abstract void StartBuilding();
    }
}
