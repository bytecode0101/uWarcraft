using System;


namespace Uwarcraft.Game.StateMachine
{
    public class MainMenu : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        AbstractState nextState;
        public override void Run()
        {            
            Console.WriteLine("Main menu, 1=NewGame, 2=ContinueGame, 3=Help");
            var ceva = Console.ReadLine();
            switch (ceva)
            {
                case "1":
                    {
                        nextState = new NewGame();
                        //game.Do();
                        break;
                    }
                case "2":
                    {
                        nextState = new ContinueGame();
                        //game.Do();
                        break;
                    }
                case "3":
                    {
                        nextState = new HelpGame();
                        //game.Do();
                        break;
                    }
                default:
                    {
                        Run();
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
