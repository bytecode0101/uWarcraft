using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Buildings.Interfaces;

namespace Uwarcraft.Buildings.BuildingUpgrades
{
    class FirstLevelUpgrade : BuildingUpgradeDecorator
    {
        public FirstLevelUpgrade(AbstractBuilding building) : base(building)
        {
            Cost = base.Cost * 2;
        }
    }
}
