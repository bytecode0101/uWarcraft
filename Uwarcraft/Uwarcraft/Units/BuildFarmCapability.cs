using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BuildFarmCapability : AbstractBuildBuildingCapability
    {
        public override IBuilding Build()
        {
            return new Farm();
        }
    }
}