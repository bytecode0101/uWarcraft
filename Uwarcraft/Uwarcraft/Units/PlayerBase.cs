﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public PlayerBase()
        {
            //BuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            //BuildingsCapabilities.Add(new BuildFarmCapability());
            UIBLC xml = new UIBLC();
            xml = XMLWork.XMLDeserialization();
            Buildings = new List<AbstractBuilding>();
            Units = new List<IUnit>();
            Resources = XMLWork.XMLStarting().resources;
            foreach (string item in xml.buildingTypes)
            {
                BuildCapabilitiesBuildings.Add(item, false);
            }
            foreach (string item in xml.unitTypes)
            {
                BuildCapabilitiesUnits.Add(item, false);
            }
            BuildCapabilitiesBuildings["Farm"] = true;
            factory = new BuildingFactory();
        }

        public void Build(string buildingType, Game.Point coords)
        {
            if (BuildCapabilitiesBuildings[buildingType])
            {
                AbstractBuilding newbuilding = factory.Build(buildingType, coords);
            }
        }
    }
}