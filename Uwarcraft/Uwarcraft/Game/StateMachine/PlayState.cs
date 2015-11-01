using System;
using Uwarcraft.Units;

namespace Uwarcraft.Game.StateMachine
{
    //public 
    /// <summary>
    /// temporary code checks if BuildingsCapabilities are working
    /// </summary>
    public class PlayState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        //AbstractState nextState;
        private PlayerBase playerBase;
        private int intField;
        private int intField2;
        //private AbstractBuilding[] buildings = new AbstractBuilding[9];

        public override void Run()
        {
            playerBase = new PlayerBase();
            //int nrOfBuildings = 0;
            //IUnit p = new Peasant(new Point(14, 14));

            //while (true)
            //{

            //    int nrOfOptions = ListBuildOptions();
            //    int option = Select();
            //    if (option <= nrOfOptions)
            //    {
            //        intField = option;
            //        intField2 = nrOfBuildings;
            //        buildings[nrOfBuildings] = playerBase.BuildingsCapabilities[option].Build(new Point(17- nrOfBuildings, 12+ nrOfBuildings));
            //        buildings[nrOfBuildings].BuildingComplete += Building_BuildingComplete;
            //        buildings[nrOfBuildings].StartBuilding();
            //        nrOfBuildings++;
            //        Console.WriteLine("total buildings ={0}", nrOfBuildings);
            //    }
            //    else
            //    {
            //        Console.WriteLine("that option # does not exist");
            //    }
            //}

        }

        //private void Building_BuildingComplete()
        //{
        //    try
        //    {
        //        playerBase.BuildingsCapabilities.Add(buildings[intField2].BuildBuildingsCapabilities[0]);
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //    }
        //    playerBase = EraseDuplicates(playerBase);
        //    buildings[intField2].Complete = true;

        //    Console.WriteLine("built " + buildings[intField2].GetType().ToString());

        //}

        private int ListBuildOptions()
        {
            string[] msg = new string[5];
            int i = 0;
            foreach (AbstractBuildBuildingCapability cap in playerBase.BuildingsCapabilities)
            {
                msg[i] = cap.GetType().ToString();
                msg[i] = msg[i].Substring(16, msg[i].Length - 26);
                Console.Write("press {0} to", i);
                Console.WriteLine(" " + msg[i]);
                i = i + 1;
            }
            return i - 1;
        }

        private int Select()
        {
            int op = 30;
            var ceva = Console.ReadLine();
            try
            {
                op = Int32.Parse(ceva);
                return op;
            }

            catch (FormatException)
            {
                Console.WriteLine("enter a number please!");
                op = Select();
            }
            return op;
        }

        private PlayerBase EraseDuplicates(PlayerBase pb)
        {
            for (int k = 0; k < pb.BuildingsCapabilities.Count-1; k++)
            {
                if (pb.BuildingsCapabilities[k].GetType().ToString().Equals(pb.BuildingsCapabilities[pb.BuildingsCapabilities.Count - 1].GetType().ToString()))
                {
                    pb.BuildingsCapabilities.RemoveAt(pb.BuildingsCapabilities.Count - 1);
                }
            }
            return pb;
        }
    }
}