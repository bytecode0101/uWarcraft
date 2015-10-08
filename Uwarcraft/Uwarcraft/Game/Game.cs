using System;
using System.Collections.Generic;
using Uwarcraft.Game.StateMachine;

namespace Uwarcraft.Game
{
    public class Game
    {
        public AbstractState CurrentState { get; set; }
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
