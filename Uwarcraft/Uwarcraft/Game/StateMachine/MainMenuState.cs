using System;



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
            if(ceva == "1") {
                GoToNewGameState();
            }

        }

        public void GoToNewGameState()
        {
            NewGameState.Run();

        }
        public void ContinueGame()
        {

        }
        public void HelpGameState()
        {

        }

    }


}
