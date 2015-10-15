using System;

namespace Uwarcraft.Game.StateMachine
{
    public class ContinueGameState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;

        public override void Run()
        {
            Console.WriteLine("no saved games, push enter to return to main menu");
            Console.ReadLine();
            if (StateFinishedEventHandler!=null)
            {
                StateFinishedEventHandler.Invoke(this, new StateEventArgs() { NextState = new MainMenuState() });
            }
            //game.CurentState = new MainMenu();
            //game.Do();
        }
    }
}