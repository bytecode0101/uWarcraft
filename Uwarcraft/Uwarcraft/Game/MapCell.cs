using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Game
{
    public class MapCell
    {
        public int Height;
        public string Use { get; private set; }

        public MapCell(int height = 0, string use = "")
        {
            Height = height;
            Use = use;
        }

    }
}
