using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BuildTowerCapability : AbstractBuildBuildingCapability
    {
        public new int Cost = 240;
        public override AbstractBuilding Build(Game.Point xy)
        {
            return new Tower(xy);
        }
    }
}