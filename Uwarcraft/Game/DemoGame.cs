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
            XmlSerializer deserializer = new XmlSerializer(typeof(UIBLC));
            // WARNING !!! You might need to change this link in order to make this project work
            TextReader reader = new StreamReader(@"C:\Users\Andrei\Source\Repos\uWarcraft\Uwarcraft\Uwarcraft\bin\Debug\F.xml");
            object obj = deserializer.Deserialize(reader);
            UIBLC uW = (UIBLC)obj;
            reader.Close();
            Console.WriteLine(uW.buildingTypes[2]+" "+uW.buildingTypes[3]+" "+uW.unitTypes[1]+uW.buildingTypes.Length+" "+uW.unitTypes.Length);
            Console.ReadLine();
            Game g = new Game(new MainMenuState());
            Console.ReadLine();
        }
    }
    public class UIBLC
    {
        public string[] buildingTypes { get; set; }
        public string[] unitTypes { get; set; }
    }
}
