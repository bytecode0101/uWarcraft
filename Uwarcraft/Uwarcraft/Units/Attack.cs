using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public class Attack : IOrder
    {
        public IUnit Target { get; set; }
        public Map Map { get; set; }
        public IUnit Unit { get; set; }

        public Attack(IUnit _unit, Map m, IUnit t)
        {
            Unit = _unit;
            Map = m;
            Target = t;
        }

        public void execute()
        {
            if ((Math.Pow((Unit.Position.x-Target.Position.x),2)+Math.Pow((Unit.Position.y-Target.Position.y),2))<Math.Pow(Unit.Range,2))
            {
                Unit.Attack(Target);
            }
            else
            {
                Pathfinding pat = new Pathfinding(Map, Unit.Position, Target.Position, Unit.Range);
                var way = pat.Astar();
                if (way[0].x==666)
                {
                }
                else
                {
                    Point next = way[way.Count-1];
                    if ((next.x-Unit.Position.x==1)&&(next.y - Unit.Position.y == -1))
                    {
                        Unit.Move(0,Map);
                    }
                    if ((next.x - Unit.Position.x == 1) && (next.y - Unit.Position.y == 0))
                    {
                        Unit.Move(1,Map);
                    }
                    if ((next.x - Unit.Position.x == 1) && (next.y - Unit.Position.y == 1))
                    {
                        Unit.Move(2,Map);
                    }
                    if ((next.x - Unit.Position.x == 0) && (next.y - Unit.Position.y == -1))
                    {
                        Unit.Move(3,Map);
                    }
                    if ((next.x - Unit.Position.x == 0) && (next.y - Unit.Position.y == 1))
                    {
                        Unit.Move(4,Map);
                    }
                    if ((next.x - Unit.Position.x == -1) && (next.y - Unit.Position.y == -1))
                    {
                        Unit.Move(5,Map);
                    }
                    if ((next.x - Unit.Position.x == -1) && (next.y - Unit.Position.y == 0))
                    {
                        Unit.Move(6,Map);
                    }
                    if ((next.x - Unit.Position.x == -1) && (next.y - Unit.Position.y == 1))
                    {
                        Unit.Move(7,Map);
                    }
                }
            }
        }
    }
}
