﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Game
{
    public class Map
    {
        public List<List<MapCell>> Data { get; private set; } // i see we're having the Map as a List of Lists of wouldn't it be better to use a bidimensional Array since we know the size of map will not modify? or a Dictionary<Points,MapCells> since we defined point as a data type - Andrei P.
        Random R = new Random();
        public Map() { Data = new List<List<MapCell>>(); } 
        public void Generate(int Width, int Height, params Point[] StartPositions)//Start pos array with min 2
        {
            Console.WriteLine("Generation Started");
            Data = new List<List<MapCell>>();
            while (Data.Count < Height)
                Data.Add(new List<MapCell>());
            foreach (List<MapCell> Row in Data)
                while (Row.Count < Width)
                    Row.Add(new MapCell(0));
            foreach (Point Pos in StartPositions)
                Data[Pos.y][Pos.x] = new MapCell(0, "SP");
            
            for (int i = 0; i < Data.Count; i++)
            {
                for (int j = 0; j < Data[i].Count; j++)
                {
                    if (R.Next(1, 101) < 32)
                        AddElement(new Point(i, j));
                }
            }

            //Generate Terrain while checking path between all start pos
            Console.WriteLine("Generation Finished");
        }



        public bool isValidForUnit(Point Pos)
        {
            if (!(Pos.x >= 0 && Pos.y >= 0 && Pos.y < Data.Count && Pos.x < Data[0].Count))
                return false;
            if (Data[Pos.y][Pos.x].Height == 0)
                return true;

            return false;
        }

        public void AddElement(Point Pos)
        {
            int H = R.Next(-50, 100);

            if (Data[Pos.y][Pos.x].Height == 0)
                Data[Pos.y][Pos.x].Height = H;
        }

    }
}
