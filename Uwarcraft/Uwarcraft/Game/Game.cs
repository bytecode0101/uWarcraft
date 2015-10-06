using System.Collections.Generic;

namespace Uwarcraft.Game
{
    class Game
    {
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
