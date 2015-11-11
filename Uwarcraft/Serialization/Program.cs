using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Uwarcraft;
using Uwarcraft.Game.StateMachine;
using Uwarcraft.Units;

namespace Serialization
{
    public class Program
    {
        //[XmlInclude(typeof(BuildFarmCapability)), XmlInclude(typeof(BuildBarrackCapability)), XmlInclude(typeof(BuildBowWorkshopCapability)), XmlInclude(typeof(BuildTowerCapability)), XmlInclude(typeof(BuildPeasantCapability)), XmlInclude(typeof(BuildArcherCapability))]
        public static void Main(string[] args)
        {
            
            var buildingTypes = new string[5] {"Farm", "Barrack","BowWorkshop","Tower","Blacksmith" };
            var unitTypes = new string[4] { "Peasant", "Archer", "Clubman", "SwordFighter" };
            UIBLC uW = new UIBLC();
            uW.BuildingTypes = buildingTypes;
            uW.UnitTypes = unitTypes;
            Serialize(uW);
            Starting s = new Starting();
            s.Resources = 200;
            Serialize(s);
            NewOptions options = new NewOptions();
            options.FarmBuildings = new string[1] { "Barrack" };
            options.FarmUnits = new string[1] { "Peasant" };
            options.BarrackBuildings = new string[1] { "BowWorkshop" };
            options.BarrackUnits = new string[1] { "Clubman" };
            options.BowWorkshopBuildings = new string[1] { "Tower" };
            options.BowWorkshopUnits = new string[1] { "Archer" };
            options.TowerBuildings = new string[1] { "Blacksmith" };
            options.BlacksmithUnits = new string[1] { "SwordFighter" };
            Serialize(options);
        }
        //[XmlInclude(typeof(BuildFarmCapability)), XmlInclude(typeof(BuildBarrackCapability)), XmlInclude(typeof(BuildBowWorkshopCapability)), XmlInclude(typeof(BuildTowerCapability)), XmlInclude(typeof(BuildPeasantCapability)), XmlInclude(typeof(BuildArcherCapability))]
        static public void Serialize(UIBLC uW)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UIBLC));
            // WARNING !!! You might need to change this link in order to make this project work
            using (TextWriter writer = new StreamWriter(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/UIBLC.xml")) 
            {
                serializer.Serialize(writer, uW);
            }
        }

        static public void Serialize(Starting s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Starting));
            // WARNING !!! You might need to change this link in order to make this project work
            using (TextWriter writer = new StreamWriter(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/starting.xml"))
            {
                serializer.Serialize(writer, s);
            }
        }

        static public void Serialize(NewOptions no)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NewOptions));
            // WARNING !!! You might need to change this link in order to make this project work
            using (TextWriter writer = new StreamWriter(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/newoptions.xml"))
            {
                serializer.Serialize(writer, no);
            }
        }
    }

    public class UIBLC
    {
        public string[] BuildingTypes { get; set; }
        public string[] UnitTypes { get; set; }
        //public AbstractBuildBuildingCapability[] buildingTypes { get; set; }
        //public AbstractBuildUnitCapability[] unitTypes { get; set; }
    }

    public class Starting
    {
        public int Resources { get; set; }
    }

    public class NewOptions
    {
        public string[] FarmBuildings { get; set; }
        public string[] FarmUnits { get; set; }
        public string[] BarrackBuildings { get; set; }
        public string[] BarrackUnits { get; set; }
        public string[] BowWorkshopBuildings { get; set; }
        public string[] BowWorkshopUnits { get; set; }
        public string[] TowerBuildings { get; set; }
        public string[] BlacksmithUnits { get; set; }

    }
}
