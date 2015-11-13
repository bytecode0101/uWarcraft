using System;
using System.Collections.Generic;
using Uwarcraft.Game;
using System.Text;

namespace Uwarcraft.Units
{
    public class PlayerBase
    {
        public List<AbstractBuilding> Buildings { get; set; }
        public List<IUnit> Units { get; set; }
        public List<AbstractBuildBuildingCapability> BuildingsCapabilities { get; set; }
        public int Resources;

        public Dictionary<string, bool> BuildCapabilitiesBuildings;
        public Dictionary<string, bool> BuildCapabilitiesUnits;
        public Dictionary<string, int> CountBuildings;
        public Dictionary<string, int> CountUnits;

        private BuildingFactory factory;
        private UnitFactory unitFactory;
        private AddNewOptions newOptions;
        private Map map;

        public PlayerBase(Map _map)
        {
            map = _map;
            BuildCapabilitiesBuildings = new Dictionary<string, bool>();
            BuildCapabilitiesUnits = new Dictionary<string, bool>();
            CountBuildings = new Dictionary<string, int>();
            CountUnits = new Dictionary<string, int>();
            UIBLC xml = new UIBLC();
            xml = XMLWork.XMLDeserialization();
            Buildings = new List<AbstractBuilding>();
            Units = new List<IUnit>();
            Resources = XMLWork.XMLStarting().resources;
            foreach (string item in xml.BuildingTypes)
            {
                BuildCapabilitiesBuildings.Add(item, false);
                CountBuildings.Add(item, 0);
            }
            foreach (string item in xml.UnitTypes)
            {
                BuildCapabilitiesUnits.Add(item, false);
                CountUnits.Add(item, 0);
            }
            BuildCapabilitiesBuildings["Farm"] = true;
            factory = new BuildingFactory();
            unitFactory = new UnitFactory();
            newOptions = new AddNewOptions();
        }

        public void Build(string buildingType, Game.Point coords)
        {
            if (map.Data[coords.y][coords.x].Use==""&& map.isValidForUnit(coords))
            {
                if (BuildCapabilitiesBuildings[buildingType])
                {
                    AbstractBuilding newbuilding = factory.Build(buildingType, coords);
                    Buildings.Add(newbuilding);
                    map.Data[coords.y][coords.x].Use = newbuilding.Type;
                    if (CountBuildings[buildingType] == 0)
                    {
                        string[] b = newOptions.Buildings(buildingType);
                        if (b != null)
                        {
                            foreach (string item in b)
                            {
                                BuildCapabilitiesBuildings[item] = true;
                            }
                        }
                        string[] u = newOptions.Units(buildingType);
                        if (u != null)
                        {
                            foreach (string item in u)
                            {
                                BuildCapabilitiesUnits[item] = true;
                            }
                        }
                    }
                    CountBuildings[buildingType]++;
                    
                }
            }
        }

        public void Train(string unitType, Game.Point coords)
        {
            if (map.Data[coords.y][coords.x].Use == "" && map.isValidForUnit(coords))
            {
                if (BuildCapabilitiesUnits[unitType])
                {
                    IUnit newUnit = unitFactory.Train(unitType, coords);
                    Units.Add(newUnit);
                    map.Data[coords.y][coords.x].Use = "unit";
                    
                    CountUnits[unitType]++;
                }
            }
        }
    }
}