using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Game.StateMachine
{
    public abstract class AbstractState
    {
        AbstractState NextState { get; set; }
        public abstract void Run();
        
    }
}
