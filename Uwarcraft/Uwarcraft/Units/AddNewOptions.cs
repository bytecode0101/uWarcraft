using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Units
{
    class AddNewOptions
    {
        private XMLWork Xml;

        public AddNewOptions()
        {
            Xml = new XMLWork();
        }

        public string[] Buildings(string type)
        {                        
            switch (type)
            {
                case ("Farm"):
                    {                        
                        string[] b = Xml.NewOptions.FarmBuildings;
                        return b;
                        //break;
                    }
                case ("Barrack"):
                    {
                        string[] b = Xml.NewOptions.BarrackBuildings;
                        return b;
                        //break;
                    }
                case ("BowWorkshop"):
                    {
                        string[] b = Xml.NewOptions.BowWorkshopBuildings;
                        return b;
                        //break;
                    }
                case ("Tower"):
                    {
                        string[] b = Xml.NewOptions.TowerBuildings;
                        return b;
                        //break;
                    }
                default:
                    break;
            }
            return null;
        }

        public string[] Units(string type)
        {
            switch (type)
            {
                case ("Farm"):
                    {
                        string[] b = Xml.NewOptions.FarmUnits;
                        return b;
                        //break;
                    }
                case ("Barrack"):
                    {
                        string[] b = Xml.NewOptions.BarrackUnits;
                        return b;
                        //break;
                    }
                case ("BowWorkshop"):
                    {
                        string[] b = Xml.NewOptions.BowWorkshopUnits;
                        return b;
                        //break;
                    }
                case ("Blacksmith"):
                    {
                        string[] b = Xml.NewOptions.BlacksmithUnits;
                        return b;
                        //break;
                    }
                default:
                    return null;
            }            
        }
    }
}
