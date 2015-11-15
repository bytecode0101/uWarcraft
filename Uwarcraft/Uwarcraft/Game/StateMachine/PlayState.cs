using System;
using System.Collections.Generic;
using System.Threading;
using Uwarcraft.Units;

namespace Uwarcraft.Game.StateMachine
{

    public class PlayState : AbstractState
    {
        public event EventHandler NewUpdate;

        public override event StateFinished StateFinishedEventHandler;
        //public event EventHandler<BuildCommandEventArgs> BuildCommand;
        public PlayerBase PlayerBase { get; set; }
        public Map Map { get; set; }
        public List<Attack> Orders { get; set; }

        public PlayState()
        {
            Orders = new List<Attack>();
            Map = new Map();
            Map = Map.Run(16, 16);
            PlayerBase = new PlayerBase(Map);
        }

        public override void Run()
        {
            //while (PlayerBase.CountBuildings["BowWorkshop"]!=3)
            for (int i = 0; i < 3; i++)            
            {
                Thread.Sleep(1300);
                foreach (Attack order in Orders)
                {
                    order.execute();
                }
                if (NewUpdate != null)
                {
                    NewUpdate(this, new EventArgs());
                }
            }
        }

        public void OnBuildCommand(object source, BuildCommandEventArgs e)
        {
            Build(e.Type, e.Coords);
        }

        public void Build(string type, Point coords)
        {
            this.PlayerBase.Build(type, coords);
            if (NewUpdate != null)
            {
                NewUpdate(this, new EventArgs() );
            }

        }

        public void OnTrainCommand(object source, BuildCommandEventArgs e)
        {
            this.PlayerBase.Train(e.Type, e.Coords);
        }

    }
}