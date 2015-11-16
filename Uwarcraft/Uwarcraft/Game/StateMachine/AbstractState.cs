using System;

namespace Uwarcraft.Game.StateMachine
{
    public delegate void StateFinished(object sender, StateEventArgs e);

    


    public abstract class AbstractState
    {
        public abstract event StateFinished StateFinishedEventHandler;
        //State NextState { get; set; }
        public abstract void Run();

    }
}
