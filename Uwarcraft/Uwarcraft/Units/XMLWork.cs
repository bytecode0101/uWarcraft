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
        public static UIBLC XMLDeserialization()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(UIBLC));
            // WARNING !!! You might need to change this link in order to make this project work
            TextReader reader = new StreamReader(@"C:\Users\roby\Source\Repos\uWarcraft5\Uwarcraft\Game\F.xml");
            object obj = deserializer.Deserialize(reader);
            UIBLC uW = (UIBLC)obj;
            reader.Close();
            return uW;
            
        }
    }

    public class UIBLC
    {
        public string[] buildingTypes { get; set; }
        public string[] unitTypes { get; set; }
    }
}
