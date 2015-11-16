using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BuildFarmCapability : AbstractBuildBuildingCapability
    {
        public new int Cost = 100;
        public override AbstractBuilding Build(Game.Point xy)
        {            
            return new Farm(xy);
        }
    }
}