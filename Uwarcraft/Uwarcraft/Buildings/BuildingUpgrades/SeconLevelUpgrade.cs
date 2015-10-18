using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Buildings.Interfaces;

namespace Uwarcraft.Buildings.BuildingUpgrades
{
    class SeconLevelUpgrade : BuildingUpgradeDecorator
    {
        public SeconLevelUpgrade(OldAbstractBuilding building) : base(building)
        {
            
        }
    }
}
