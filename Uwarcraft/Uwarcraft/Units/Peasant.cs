using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{    
    public class Peasant : Units.IUnit
    {
        public int unitCost { get; set; }
        public int unitHealth { get; set; }
        public int unitSpeed { get; set; }
        public int unitDamageSuffered { get; set; }
        public int unitAttackPower { get; set; }
        public int UnitRange { get; set; }
        public Game.Point position { get; set; }
        public string Type { get; set; }
        public event EventHandler UnitDestroyed;

        public Peasant(Game.Point xy)
        {
            position = xy;
            unitHealth = 20;
            unitSpeed = 1;
            unitAttackPower = 1;
            UnitRange = 2;
            Type = "Peasant";
        }

        public void Attack(IUnit target)
        {
            target.TakeHit(unitAttackPower);
            if (target.unitDamageSuffered >= target.unitHealth)
            {
                target = null;
            }
        }

        public void Attack(AbstractBuilding target)
        {
            target.TakeHit(unitAttackPower);
            //target.TakeHit(unitAttackPower);
            //if (target.Life <= target.DamageTaken)
            //{
            //    target = null;
            //}
        }

        public void Move(int i)
        {
            int[] a = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] b = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
            position.x += a[i];
            position.y += b[i];
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void TakeHit(int attackPower)
        {
            unitDamageSuffered += attackPower;
            if (unitHealth <= unitDamageSuffered)
            {
                if (UnitDestroyed!=null)
                {
                    UnitDestroyed(this, new EventArgs());
                }
            }
        }
    }
}