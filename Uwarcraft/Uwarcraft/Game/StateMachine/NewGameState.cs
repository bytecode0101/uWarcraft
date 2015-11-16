using System;

namespace Uwarcraft.Game.StateMachine
{
    public class NewGameState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        //AbstractState nextState;
        public override void Run()
        {

            Console.WriteLine("press enter to start game");
            Console.ReadLine();
            
            if (StateFinishedEventHandler != null)
            {
                StateFinishedEventHandler.Invoke(this, new StateEventArgs() { NextState = new PlayState() });
            }

        }
    }
}