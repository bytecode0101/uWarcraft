using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uwarcraft.Units
{
    public  class XMLWork
    {
        public NewOptions NewOptions { get; set; }

        public XMLWork()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(NewOptions));
            TextReader reader = new StreamReader(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/newoptions.xml");
            object obj = deserializer.Deserialize(reader);
            NewOptions = (NewOptions)obj;
            reader.Close();
        }

        public static UIBLC XMLDeserialization()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(UIBLC));
            TextReader reader = new StreamReader(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/UIBLC.xml");
            object obj = deserializer.Deserialize(reader);
            UIBLC uW = (UIBLC)obj;
            reader.Close();
            return uW;            
        }

        public static Starting XMLStarting()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Starting));
            TextReader reader = new StreamReader(@"C:/Users/Andrei/Source/Repos/uWarcraft/Uwarcraft/Serialization/starting.xml");
            object obj = deserializer.Deserialize(reader);
            Starting s = (Starting)obj;
            reader.Close();
            return s;
        }
        //public static NewOptions XMLNewOptions()
        //{
        //    XmlSerializer deserializer = new XmlSerializer(typeof(NewOptions));
        //    TextReader reader = new StreamReader(@"newoptions.xml");
        //    object obj = deserializer.Deserialize(reader);
        //    NewOptions no = (NewOptions)obj;
        //    reader.Close();
        //    return no;
        //}
    }

    public class UIBLC
    {
        public string[] BuildingTypes { get; set; }
        public string[] UnitTypes { get; set; }
    }

    public class Starting
    {
        public int resources { get; set; }
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
