using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class Archer : Units.IUnit
    {
        public int unitCost { get; set; }
        public int unitHealth { get; set; }
        public int unitSpeed { get; set; }
        public int unitDamageSuffered { get; set; }
        public int unitAttackPower { get; set; }
        public Game.Point position { get; set; }
        public string Type { get; set; }

        public Archer(Game.Point xy)
        {
            position = xy;
            unitHealth = 30;
            unitSpeed = 1;
            unitAttackPower = 4;
            Type = "Archer";
        }

        public void Attack(IUnit target)
        {
            target.TakeHit(unitAttackPower);
            if (target.unitDamageSuffered >= target.unitHealth)
            {
                target.unitCost = 0;
                target.unitHealth = 0;
                target.unitSpeed = 0;
                target.unitAttackPower = 0;
                target.position = null;
            }
        }

        public void Attack(AbstractBuilding target)
        {
            target.TakeHit(unitAttackPower);
            if (target.Life <= target.DamageTaken)
            {
                target = null;
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void TakeHit(int attackPower)
        {
            unitDamageSuffered += attackPower;
        }
    }
}