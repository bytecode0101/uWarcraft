using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{

    public interface IBuildable
    {
        event EventHandler Destroyed;
        Point Position { get; set; }
        int Life { get; set; }
        int DamageTaken { get; set; }
        string Type { get; set; }
        bool Complete { get; set; }

        void TakeHit(int attackPower);
    }
}
