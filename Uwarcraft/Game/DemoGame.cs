using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;
using Uwarcraft.Game.StateMachine;

namespace DemoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.CurrentState = new MainMenuState();
            g.Run();
            Console.ReadLine();
        }
    }
}
