using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Units
{
    class Barrack : IBuilding
    {
        public List<AbstractBuildBuildingCapability> BuildBuildingsCapabilities
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<AbstractBuildUnitCapability> BuildUnitCapabilities
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event BuildingComplete BuildingComplete;

        public void StartBuilding()
        {
            throw new NotImplementedException();
        }
    }
}
