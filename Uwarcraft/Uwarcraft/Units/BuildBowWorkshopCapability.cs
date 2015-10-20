using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BuildBowWorkshopCapability : AbstractBuildBuildingCapability
    {
        public new int Cost = 150;
        public override IBuilding Build(Game.Point xy)
        {
            return new BowWorkshop(xy);
        }
    }
}