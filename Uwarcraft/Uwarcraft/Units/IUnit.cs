using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public interface IUnit : IBuildable
    {
        int Cost { get; set; }
        int Speed { get; set; }
        int AttackPower { get; set; }
        int Range { get; set; }

        void Attack(IUnit target);
        void Attack(AbstractBuilding target);
        void Move(int i, Map map);
        void Stop();
        
    }
}
