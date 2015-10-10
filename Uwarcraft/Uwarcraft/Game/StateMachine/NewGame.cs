using System;

namespace Uwarcraft.Game.StateMachine
{
    public class NewGame : AbstractState
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
                        nextState = new MainMenu();
                        //game.Do();
                        break;
                    }
                case 1:
                    {
                        nextState = new ContinueGame();
                        //game.Do();
                        break;
                    }
                case 2:
                    {
                        nextState = new HelpGame();
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