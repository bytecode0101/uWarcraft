using System;
using Uwarcraft.Buildings.Interfaces;
using Uwarcraft.Game;

namespace Uwarcraft.Buildings.BasicBuildings
{
    public class Farm : AbstractBuilding
    {
        public Farm(Point location,int life )
        {
            Cost = 100;
            Life = life;
            Location = location;
        }
    }
}
