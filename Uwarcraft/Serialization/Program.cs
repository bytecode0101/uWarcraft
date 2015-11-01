using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Uwarcraft;
using Uwarcraft.Units;

namespace Serialization
{
    public class Program
    {
        //[XmlInclude(typeof(BuildFarmCapability)), XmlInclude(typeof(BuildBarrackCapability)), XmlInclude(typeof(BuildBowWorkshopCapability)), XmlInclude(typeof(BuildTowerCapability)), XmlInclude(typeof(BuildPeasantCapability)), XmlInclude(typeof(BuildArcherCapability))]
        static void Main(string[] args)
        {
            var buildingTypes = new string[4] {"Farm", "Barack","BowWorkshop","Tower" };
            var unitTypes = new string[2] { "Peasant", "Archer" };
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
        }
        //[XmlInclude(typeof(BuildFarmCapability)), XmlInclude(typeof(BuildBarrackCapability)), XmlInclude(typeof(BuildBowWorkshopCapability)), XmlInclude(typeof(BuildTowerCapability)), XmlInclude(typeof(BuildPeasantCapability)), XmlInclude(typeof(BuildArcherCapability))]
        static public void Serialize(UIBLC uW)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UIBLC));
            // WARNING !!! You might need to change this link in order to make this project work
            using (TextWriter writer = new StreamWriter(@"C:\Users\Andrei\Source\Repos\uWarcraft\Uwarcraft\Uwarcraft\bin\Debug\F.xml")) 
            {
                serializer.Serialize(writer, uW);
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
}
