using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uwarcraft.Game;
using Uwarcraft.Units;
using Uwarcraft.Game.StateMachine;
using NLog;

namespace WpfApplicationUwarcraft
{
    //public delegate void BuildCommandEventHandler(Button button, BuildCommandEventArgs type);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler<BuildCommandEventArgs> BuildCommand;
        public event EventHandler<BuildCommandEventArgs> TrainCommand;
        private static Logger log = LogManager.GetCurrentClassLogger(); 
        Game g;
        PlayState st;
        UIBLC denumiri;

        public MainWindow()
        {
            InitializeComponent();
            log.Trace("MainWindow initialized");
            //Thread states = new Thread(new ThreadStart(runGame));
            //states.Start();
            denumiri = new Uwarcraft.Units.UIBLC();
            denumiri = XMLWork.XMLDeserialization();
            g = new Game(new PlayState());
            st = (PlayState)g.CurrentState;
            //Thread gRun = new Thread(st.Run);
            //gRun.Start();
            st.Run();
            //var buildings = st.PlayerBase.Buildings;
            //var units = st.PlayerBase.Units;
            BuildCommand += st.OnBuildCommand;
            TrainCommand += st.OnTrainCommand;
            st.NewUpdate += OnNewUpdate;
            Console.ReadLine();


            ShowBuildMenu();
            ShowTrainMenu();

            for (int i = 0; i < st.PlayerBase.Buildings.Count; i++)
            {
                TextBlock item = new TextBlock();
                item.Name = i.ToString();
                item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Buildings[i].Type, st.PlayerBase.Buildings[i].Life, st.PlayerBase.Buildings[i].DamageTaken, st.PlayerBase.Buildings[i].Location.ToString(), st.PlayerBase.Buildings[i].Complete.ToString());
                stack3.Children.Add(item);
                log.Trace("showing Building Options");
            }
        }

        public void ShowTrainMenu()
        {
            try
            {
                string[] B = denumiri.UnitTypes;
                stack2.Children.Clear();
                for (int i = 0; i < B.Length; i++)
                {
                    if (st.PlayerBase.BuildCapabilitiesUnits[B[i]] == true)
                    {
                        Button button1 = new Button();
                        button1.Content = B[i];
                        button1.Name = B[i];
                        stack2.Children.Add(button1);
                    }
                }
                log.Trace("TrainMenu refreshed");
            }
            catch (Exception)
            {
            }
        }

        public void ShowBuildMenu()
        {
            try
            {
                string[] A = denumiri.BuildingTypes;
                stack1.Children.Clear();
                for (int i = 0; i < A.Length; i++)
                {
                    if (st.PlayerBase.BuildCapabilitiesBuildings[A[i]] == true)
                    {
                        Button button1 = new Button();
                        button1.Content = A[i];
                        button1.Name = A[i];
                        stack1.Children.Add(button1);
                    }

                }
                log.Trace("BuildMenu refreshed");
            }
            catch (Exception)
            {
            }
        }

        //private void runGame()
        //{
        //    Game g = new Game(new PlayState());
        //    var st = (PlayState)g.CurrentState;
        //    Thread gRun = new Thread(st.Run);
        //    gRun.Start();
        //    var buildings = st.PlayerBase.Buildings;
        //    var units = st.PlayerBase.Units;
        //    Console.ReadLine();
        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)e.OriginalSource;
            int x = Int32.Parse(textBox1.Text);
            int y = Int32.Parse(textBox2.Text);
            OnBuildCommand(btn.Name, new Uwarcraft.Game.Point(x, y));
        }

        public void OnNewUpdate(object source, EventArgs e)
        {
            ShowBuildMenu();
            ShowTrainMenu();
            ShowUnits();
            ShowOrders();
        }

        public void OnBuildCommand(string type, Uwarcraft.Game.Point coords)
        {
            if (BuildCommand != null)
            {
                BuildCommandEventArgs e = new BuildCommandEventArgs() { Coords = coords, Type = type };
                BuildCommand(this, e);
                var st = (PlayState)g.CurrentState;
                //st.Run();
                var buildings = st.PlayerBase.Buildings;
                stack3.Children.Clear();
                for (int i = 0; i < st.PlayerBase.Buildings.Count; i++)
                {
                    TextBlock item = new TextBlock();
                    item.Name = "b" + i.ToString();
                    item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Buildings[i].Type, st.PlayerBase.Buildings[i].Life, st.PlayerBase.Buildings[i].DamageTaken, st.PlayerBase.Buildings[i].Location.ToString(), st.PlayerBase.Buildings[i].Complete.ToString());
                    stack3.Children.Add(item);
                    textBox3.Text = string.Format("Farm{0}  Barrack{1}  BowWorkshop{2}  Tower{3}", st.PlayerBase.CountBuildings["Farm"], st.PlayerBase.CountBuildings["Barrack"], st.PlayerBase.CountBuildings["BowWorkshop"], st.PlayerBase.CountBuildings["Tower"]);
                }
            }
        }

        private void g2_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = (Button)e.OriginalSource;
            int x = Int32.Parse(textBox1.Text);
            int y = Int32.Parse(textBox2.Text);
            OnTrainCommand(btn.Name, new Uwarcraft.Game.Point(x, y));
        }

        public void OnTrainCommand(string type, Uwarcraft.Game.Point coords)
        {
            if (TrainCommand != null)
            {
                BuildCommandEventArgs e = new BuildCommandEventArgs() { Coords = coords, Type = type };
                TrainCommand(this, e);
                var st = (PlayState)g.CurrentState;
                var units = st.PlayerBase.Units;
                stack4.Children.Clear();
                for (int i = 0; i < st.PlayerBase.Units.Count; i++)
                {
                    TextBlock item = new TextBlock();
                    item.Name = "u" + i.ToString();
                    item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Units[i].Type, st.PlayerBase.Units[i].unitHealth, st.PlayerBase.Units[i].unitDamageSuffered, st.PlayerBase.Units[i].position.ToString(), st.PlayerBase.Units[i].UnitRange);
                    stack4.Children.Add(item);
                }
            }
        }

        private void buta_click(object sender, RoutedEventArgs e)
        {
            var v = (PlayState)g.CurrentState;
            int x = Int32.Parse(textBox1.Text);
            int y = Int32.Parse(textBox2.Text);
            Uwarcraft.Units.IOrder att = new Attack(st.PlayerBase.Units[x], v.Map, st.PlayerBase.Units[y]);
            v.AddAttack(att);
            ShowOrders();
            e.Handled = true;
        }

        private void ShowUnits()
        {
            try
            {
                stack4.Children.Clear();
                for (int i = 0; i < st.PlayerBase.Units.Count; i++)
                {
                    TextBlock item = new TextBlock();
                    item.Name = "u" + i.ToString();
                    item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Units[i].Type, st.PlayerBase.Units[i].unitHealth, st.PlayerBase.Units[i].unitDamageSuffered, st.PlayerBase.Units[i].position.ToString(), st.PlayerBase.Units[i].UnitRange);
                    stack4.Children.Add(item);
                }
            }
            catch (Exception)
            {
            }
        }

        private void ShowOrders()
        {
            try
            {
                stack5.Children.Clear();
                for (int i = 0; i < st.Orders.Count; i++)
                {
                    TextBlock item = new TextBlock();
                    item.Name = "o" + i.ToString();
                    var j = (Attack)st.Orders[i];
                    item.Text = string.Format("{0} {1} -> {2} {3} ", j.Unit.Type, j.Unit.position, j.Target.Type, j.Target.position);
                    stack5.Children.Add(item);
                }
            }
            catch (Exception)
            {
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            st.Run();
            e.Handled = true;
        }
    }

    //public class BuildCommandEventArgs
    //{
    //    public string type { get; set; }
    //}
}
