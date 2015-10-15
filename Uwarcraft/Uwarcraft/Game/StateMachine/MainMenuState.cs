using System;


namespace Uwarcraft.Game.StateMachine
{
    public class MainMenuState : AbstractState
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
                        nextState = new NewGameState();
                        //game.Do();
                        break;
                    }
                case "2":
                    {
                        nextState = new ContinueGameState();
                        //game.Do();
                        break;
                    }
                case "3":
                    {
                        nextState = new HelpGameState();
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
