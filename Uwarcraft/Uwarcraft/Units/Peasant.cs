using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{    
    public class Peasant : Units.IUnit
    {
        public int Cost { get; set; }
        public int Life { get; set; }
        public int Speed { get; set; }
        public int DamageTaken { get; set; }
        public int AttackPower { get; set; }
        public int Range { get; set; }
        public Point Position { get; set; }
        public string Type { get; set; }
        public event EventHandler Destroyed;
        public bool Complete { get; set; }

        public Peasant(Point xy)
        {
            Position = xy;
            Life = 20;
            Speed = 1;
            AttackPower = 1;
            Range = 2;
            Type = "Peasant";
        }

        public void Attack(IUnit target)
        {
            target.TakeHit(AttackPower);
            if (target.DamageTaken >= target.Life)
            {
                target = null;
            }
        }

        public void Attack(AbstractBuilding target)
        {
            target.TakeHit(AttackPower);
            //target.TakeHit(unitAttackPower);
            //if (target.Life <= target.DamageTaken)
            //{
            //    target = null;
            //}
        }

        public void Move(int i, Map map)
        {
            int[] a = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] b = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
            map.Data[Position.y][Position.x].Use = "";
            Position.x += a[i];
            Position.y += b[i];
            map.Data[Position.y][Position.x].Use = "Peasant";
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void TakeHit(int attackPower)
        {
            DamageTaken += attackPower;
            if (Life <= DamageTaken)
            {
                if (Destroyed!=null)
                {
                    Destroyed(this, new EventArgs());
                }
            }
        }
    }
}