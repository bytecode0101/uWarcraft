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
            
            var buildingTypes = new string[5] {"Farm", "Barack","BowWorkshop","Tower","Blacksmith" };
            var unitTypes = new string[4] { "Peasant", "Archer", "Clubman", "SwordFighter" };
            UIBLC uW = new UIBLC();
            //var buildingTypes = new AbstractBuildBuildingCapability[4];
            //buildingTypes[0] = new BuildFarmCapability();
            //buildingTypes[1] = new BuildBarrackCapability();
            //buildingTypes[2] = new BuildBowWorkshopCapability();
            //buildingTypes[3] = new BuildTowerCapability();
            //var unitTypes = new AbstractBuildUnitCapability[2];
            //unitTypes[0] = new BuildPeasantCapability();
            //unitTypes[1] = new BuildArcherCapability();
            //UIBLC uW = new UIBLC();
            uW.buildingTypes = buildingTypes;
            uW.unitTypes = unitTypes;
            Serialize(uW);
            starting s = new starting();
            s.resources = 200;
            Serialize(s);
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

        static public void Serialize(starting s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(starting));
            // WARNING !!! You might need to change this link in order to make this project work
            using (TextWriter writer = new StreamWriter(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/starting.xml"))
            {
                serializer.Serialize(writer, s);
            }
        }
    }

    public class UIBLC
    {
        public string[] buildingTypes { get; set; }
        public string[] unitTypes { get; set; }
        //public AbstractBuildBuildingCapability[] buildingTypes { get; set; }
        //public AbstractBuildUnitCapability[] unitTypes { get; set; }
    }

    public class starting
    {
        public int resources { get; set; }
    }
}
