using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }


        public override void Run()
        {
            Console.WriteLine("State: " + this.GetType().ToString());
        }

        public void GoToNewGameState()
        {

        }
        public void ContinueGame()
        {

        }
        public void HelpGameState()
        {

        }

    }

   
}
