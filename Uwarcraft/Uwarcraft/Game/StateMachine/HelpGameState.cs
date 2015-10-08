using System;

namespace Uwarcraft.Game.StateMachine
{
    internal class HelpGameState : AbstractState
    {
        public override void Run()
        {
            Console.WriteLine("State: " + this.GetType().ToString());
        }
    }
}