using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Uwarcraft.Game;
using Uwarcraft.Game.StateMachine;

namespace DemoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game g = new Game(new MainMenuState());
            Console.ReadLine();
        }
    }
    
}
