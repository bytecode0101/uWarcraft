﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class PlayerBase
    {
        public List<AbstractBuilding> Buildings { get; set; }
        public List<>
        public List<AbstractBuildBuildingCapability> BuildingsCapabilities { get; set; }

        public Dictionary<string, bool> BuildCapabilitiesBuildings;

        public PlayerBase()
        {
            BuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildingsCapabilities.Add(new BuildFarmCapability());

        }
    }
}