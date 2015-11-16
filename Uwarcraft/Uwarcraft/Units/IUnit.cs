using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public interface IUnit
    {
        event EventHandler UnitDestroyed;
        int unitCost { get; set; }
        int unitHealth { get; set; }
        int unitSpeed { get; set; }
        int unitDamageSuffered { get; set; }
        int unitAttackPower { get; set; }
        int UnitRange { get; set; }
        Point position { get; set; }
        string Type { get; set; }

        void Attack(IUnit target);
        void Attack(AbstractBuilding target);
        void Move(int i, Map map);
        void Stop();
        void TakeHit(int attackPower);
    }
}
