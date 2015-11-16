using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class AbstractBuildUnitCapability
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

        public IUnit Build()
        {
            throw new System.NotImplementedException();
        }
    }
}