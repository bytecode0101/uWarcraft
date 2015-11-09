using System;
using Uwarcraft.Units;

namespace Uwarcraft.Game.StateMachine
{
    
    public class PlayState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;
        //public event EventHandler<BuildCommandEventArgs> BuildCommand;
        public PlayerBase PlayerBase;

        public PlayState ()
        {
            PlayerBase = new PlayerBase();
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


        
    }
}