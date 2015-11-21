using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;


namespace Uwarcraft.Units
{
    public delegate void BuildingComplete();

    public abstract class AbstractBuilding : IBuilding
    {
        public abstract event BuildingComplete BuildingComplete;
        public abstract event EventHandler Destroyed;

        public int Life { get; set; }
        public int DamageTaken { get; set; }
        public string Type { get; set; }
        public Point Position { get; set; }
        public bool Complete { get; set; }

        

        public virtual void TakeHit(int attackPower)
        {
            DamageTaken += attackPower;
        }

        public abstract void StartBuilding();

        
    }
}
