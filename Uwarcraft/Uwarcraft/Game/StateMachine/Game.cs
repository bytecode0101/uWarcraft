using System.Collections.Generic;

namespace Uwarcraft.Game.StateMachine
{
    public class Game
    {
        private AbstractState _state; 
        
        public AbstractState CurrentState
        {
            get { return _state; }
            set { _state = value; }
        }

        public Game (AbstractState state)
        {
            CurrentState = state;
            CurrentState.StateFinishedEventHandler += CurentState_StateFinishedEventHandler;
            //_state.Run();
        }

        private void CurentState_StateFinishedEventHandler(object sender, StateEventArgs e)
        {
            CurrentState.StateFinishedEventHandler -= CurentState_StateFinishedEventHandler;
            CurrentState = e.NextState;
            CurrentState.StateFinishedEventHandler += CurentState_StateFinishedEventHandler;
            CurrentState.Run();
        }

        public void ChangeState(AbstractState nextState)
        {

        }
        private List<Player> players;
        private Map map;

        internal Map Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }

        public void Run()
        {
            CurrentState.Run();
        }

        internal List<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }
    }
}
