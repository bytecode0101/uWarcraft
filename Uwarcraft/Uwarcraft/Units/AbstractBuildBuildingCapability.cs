using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units

{
    public abstract class AbstractBuildBuildingCapability
    {
        public string Description
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract IBuilding Build();
        
        
    }
}