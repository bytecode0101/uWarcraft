using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units

{
    public abstract class AbstractBuildBuildingCapability
    {
        public string Description { get; set; }
        public int Cost { get; set; }
        public abstract IBuilding Build(Game.Point xy);
        
        
    }
}