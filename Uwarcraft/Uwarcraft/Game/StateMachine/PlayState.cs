using System;
using Uwarcraft.Units;

namespace Uwarcraft.Game.StateMachine
{
    
    public class PlayState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        //public event EventHandler<BuildCommandEventArgs> BuildCommand;
        public PlayerBase PlayerBase { get; set; }
        public Map Map { get; set; }

        public PlayState ()
        {
            
            Map = new Map();
            Map = Map.Run(24, 24);
            PlayerBase = new PlayerBase(Map);
        }

        public override void Run()
        {

        }

        public void OnBuildCommand (object source, BuildCommandEventArgs e)
        {
            Build(e.Type, e.Coords);
        }

        public void Build(string type, Point coords)
        {
            this.PlayerBase.Build(type, coords);
        }

        public void OnTrainCommand(object source, BuildCommandEventArgs e)
        {
            this.PlayerBase.Train(e.Type, e.Coords);
        }

    }
}