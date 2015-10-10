using System;

namespace Uwarcraft.Game.StateMachine
{
    public class StateEventArgs : EventArgs
    {
        public AbstractState NextState { get; set; }
    }
}
