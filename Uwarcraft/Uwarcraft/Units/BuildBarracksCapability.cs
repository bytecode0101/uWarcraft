using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class BuildBarrackCapability : AbstractBuildBuildingCapability
    {
        public new int Cost = 200;
        public override AbstractBuilding Build(Game.Point xy)
        {            
            return new Barrack(xy);
        }
    }
}