using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Uwarcraft.Units;
using Uwarcraft.Game.StateMachine;

namespace DemoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UIBLC robert = new UIBLC();
            robert = XMLWork.XMLDeserialization();
            Console.WriteLine(robert.buildingTypes[2] + " " + robert.buildingTypes[3] + " " + robert.unitTypes[1] + robert.buildingTypes.Length + " " + robert.unitTypes.Length);
            Console.ReadLine();
            Game g = new Game(new MainMenuState());
            Console.ReadLine();
        }
    }
    
}
