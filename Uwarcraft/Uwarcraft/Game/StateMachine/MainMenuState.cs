using System;
using Uwarcraft.Game;


namespace Uwarcraft.Game.StateMachine
{
    public class MainMenuState : AbstractState
    {
        private AbstractState NewGameState;
        private AbstractState ContinueGameState;
        private AbstractState HelpState;
        

        public MainMenuState()
        {
            NewGameState = new NewGameState();
            ContinueGameState = new ContinueGameState();
            HelpState = new HelpGameState();

            Game DemoGame = new Game();

        }

        public override void Run()
        {
            
            Console.WriteLine("State: " + this.GetType().ToString());

            var ceva = Console.ReadLine();
            if (ceva == "1")
            {

                GoToNewGameState();
            }
            else
            {
                if (ceva == "2")
                {
                    GoToHelpGameState();
                }
            }

        }

        public void GoToNewGameState()
        {
            NewGameState.Run();
        }

        public void ContinueGame()
        {

        }
        public void GoToHelpGameState()
        {
            HelpState.Run();
        }

    }


}
