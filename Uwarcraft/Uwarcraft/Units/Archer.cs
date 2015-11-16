using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public class Archer : Units.IUnit
    {
        public int unitCost { get; set; }
        public int unitHealth { get; set; }
        public int unitSpeed { get; set; }
        public int unitDamageSuffered { get; set; }
        public int unitAttackPower { get; set; }
        public int UnitRange { get; set; }
        public Point position { get; set; }
        public string Type { get; set; }
        public event EventHandler UnitDestroyed;

        public Archer(Point xy)
        {
            position = xy;
            unitHealth = 30;
            unitSpeed = 1;
            unitAttackPower = 4;
            UnitRange = 5;
            Type = "Archer";
        }

        public void Attack(IUnit target)
        {
            target.TakeHit(unitAttackPower);
            //if (target.unitDamageSuffered >= target.unitHealth)
            //{
            //    target.unitCost = 0;
            //    target.unitHealth = 0;
            //    target.unitSpeed = 0;
            //    target.unitAttackPower = 0;
            //    target.position = null;
            //}
        }

        public void Attack(AbstractBuilding target)
        {
            target.TakeHit(unitAttackPower);
            //if (target.Life <= target.DamageTaken)
            //{
            //    target = null;
            //}
        }

        public void Move(int i, Map map)
        {
            int[] a = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] b = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
            map.Data[position.y][position.x].Use = "";
            position.x += a[i];
            position.y += b[i];
            map.Data[position.y][position.x].Use = "Archer";
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
                if (UnitDestroyed != null)
                {
                    UnitDestroyed(this, new EventArgs());
                }
            }
        }
    }
}