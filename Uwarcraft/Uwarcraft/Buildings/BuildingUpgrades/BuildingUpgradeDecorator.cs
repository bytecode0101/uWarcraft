using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Buildings.Interfaces;

namespace Uwarcraft.Buildings.BuildingUpgrades
{
    abstract class BuildingUpgradeDecorator : OldAbstractBuilding
    {
        private OldAbstractBuilding baseBuilding;

        public BuildingUpgradeDecorator(OldAbstractBuilding building)
        {
            baseBuilding = building;
        }

        public override void TakeHit(int hitPower)
        {
            baseBuilding.TakeHit(hitPower);
        }
    }
}
