using System;
using System.Collections.Generic;
using System.Threading;
using Uwarcraft.Units;

namespace Uwarcraft.Game.StateMachine
{

    public class PlayState : AbstractState
    {
        public event EventHandler NewUpdate;
        public event EventHandler <StringEventArgs> UIMessage;

        public override event StateFinished StateFinishedEventHandler;
        //public event EventHandler<BuildCommandEventArgs> BuildCommand;
        public PlayerBase PlayerBase { get; set; }
        public Map Map { get; set; }
        public List<IOrder> Orders { get; set; }
        List<IOrder> ordersToRemove;

        public PlayState()
        {
            Orders = new List<IOrder>();
            Map = new Map();
            Map = Map.Run(16, 16);
            PlayerBase = new PlayerBase(Map);
            ordersToRemove = new List<IOrder>();
        }

        public override void Run()
        {
            //while (PlayerBase.CountBuildings["BowWorkshop"]!=3)
            //for (int i = 0; i < 3; i++)            
            //{
            //Thread.Sleep(1300);

            foreach (IOrder order in Orders)
            {
                order.execute();
            }
            foreach (IOrder item in ordersToRemove)
            {
                Orders.Remove(item);
            }
            ordersToRemove.Clear();
            if (NewUpdate != null)
            {
                NewUpdate(this, new EventArgs());
            }
            //}
        }

        public void AddAttack(IOrder order)
        {
            foreach (IOrder item in Orders)
            {
                if (order.Unit == item.Unit)
                {
                    Orders.Remove(item);
                    break;
                }
            }
            Orders.Add(order);
        }

        public void OnBuildCommand(object source, BuildCommandEventArgs e)
        {
            Build(e.Type, e.Coords);
        }

        public void Build(string type, Point coords)
        {
            if (this.PlayerBase.Build(type, coords))
            {
                UIMessage(this, new StringEventArgs() { Msg = string.Format("{0} built", type) });
            }                        
            if (NewUpdate != null)
            {
                NewUpdate(this, new EventArgs());
            }
        }        

        public void OnTrainCommand(object source, BuildCommandEventArgs e)
        {
            if (this.PlayerBase.Train(e.Type, e.Coords))
            {
                PlayerBase.Units[PlayerBase.Units.Count - 1].Destroyed += OnUnitDestroyed;
                UIMessage(this, new StringEventArgs() { Msg = string.Format("{0} trained", e.Type) });
            }
        }

        public void OnUnitDestroyed(object source, EventArgs e)
        {
            foreach (IOrder item in Orders)
            {
                if (source == item.Unit)
                {
                    ordersToRemove.Add(item);
                    break;
                }
            }
            foreach (IOrder item in Orders)
            {
                try
                {
                    var j = (Attack)item;
                    if (source == j.Target)
                    {
                        ordersToRemove.Add(item);                        
                    }
                }
                catch (Exception)
                {
                }

            }
            PlayerBase.Units.Remove((IUnit)source);
            IUnit k = (IUnit)source;
            PlayerBase.map.Data[k.Position.y][k.Position.x].Use = "";
            k.Destroyed -= OnUnitDestroyed;

            UIMessage(this, new StringEventArgs() { Msg = string.Format("{0} destroyed", k.Type) });
            if (NewUpdate != null)
            {
                NewUpdate(this, new EventArgs());
            }
        }
    }
}