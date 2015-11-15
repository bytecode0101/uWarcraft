using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public class Attack : ICommand
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
            if ((Math.Pow((Unit.position.x-Target.position.x),2)+Math.Pow((Unit.position.y-Target.position.y),2))<Math.Pow(Unit.UnitRange,2))
            {
                Unit.Attack(Target);
            }
            else
            {
                Pathfinding pat = new Pathfinding(Map, Unit.position, Target.position, Unit.UnitRange);
                var way = pat.Astar();
                if (way[0].x==666)
                {
                }
                else
                {
                    Point next = way[way.Count-1];
                    if ((next.x-Unit.position.x==1)&&(next.y - Unit.position.y == -1))
                    {
                        Unit.Move(0);
                    }
                    if ((next.x - Unit.position.x == 1) && (next.y - Unit.position.y == 0))
                    {
                        Unit.Move(1);
                    }
                    if ((next.x - Unit.position.x == 1) && (next.y - Unit.position.y == 1))
                    {
                        Unit.Move(2);
                    }
                    if ((next.x - Unit.position.x == 0) && (next.y - Unit.position.y == -1))
                    {
                        Unit.Move(3);
                    }
                    if ((next.x - Unit.position.x == 0) && (next.y - Unit.position.y == 1))
                    {
                        Unit.Move(4);
                    }
                    if ((next.x - Unit.position.x == -1) && (next.y - Unit.position.y == -1))
                    {
                        Unit.Move(5);
                    }
                    if ((next.x - Unit.position.x == -1) && (next.y - Unit.position.y == 0))
                    {
                        Unit.Move(6);
                    }
                    if ((next.x - Unit.position.x == -1) && (next.y - Unit.position.y == 1))
                    {
                        Unit.Move(7);
                    }
                }
            }
        }
    }
}
