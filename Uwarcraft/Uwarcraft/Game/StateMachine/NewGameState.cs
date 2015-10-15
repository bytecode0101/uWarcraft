using System;

namespace Uwarcraft.Game.StateMachine
{
    public class NewGameState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        AbstractState nextState;
        public override void Run()
        {
            Console.WriteLine("game no yet implemented, press enter to go to another state randomly picked");
            Console.ReadLine();
            Random rnd = new Random();
            int dice = rnd.Next(0, 3);
            
            switch (dice)
            {
                case 0:
                    {
                        nextState = new MainMenuState();
                        //game.Do();
                        break;
                    }
                case 1:
                    {
                        nextState = new ContinueGameState();
                        //game.Do();
                        break;
                    }
                case 2:
                    {
                        nextState = new HelpGameState();
                        //game.Do();
                        break;
                    }
            }
            if (StateFinishedEventHandler != null)
            {
                StateFinishedEventHandler.Invoke(this, new StateEventArgs() { NextState = nextState });
            }

        }
    }
}