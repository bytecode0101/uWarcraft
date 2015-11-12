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

namespace WpfApplicationUwarcraft
{
    //public delegate void BuildCommandEventHandler(Button button, BuildCommandEventArgs type);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public event EventHandler<BuildCommandEventArgs> BuildCommand;

        public Game g;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("starting thread");
            //Thread states = new Thread(new ThreadStart(runGame));
            //states.Start();

            g = new Game(new PlayState());
            var st = (PlayState)g.CurrentState;
            var buildings = st.PlayerBase.Buildings;
            var units = st.PlayerBase.Units;
            BuildCommand += st.OnBuildCommand;
            Console.ReadLine();

            Uwarcraft.Units.UIBLC denumiri = new Uwarcraft.Units.UIBLC();
          denumiri= XMLWork.XMLDeserialization();
            int xx = denumiri.buildingTypes.Length;
            int yy = denumiri.unitTypes.Length;
            for (int i = 0; i < xx; i++)
            {
                Button button1 = new Button();
                button1.Content = denumiri.buildingTypes[i];
                button1.Name = denumiri.buildingTypes[i];
                stack1.Children.Add(button1);
            }

            for (int i = 0; i < yy; i++)
            {
                Button button1 = new Button();
                button1.Content = denumiri.unitTypes[i];
                button1.Name = denumiri.unitTypes[i];
                stack2.Children.Add(button1);
            }

            for (int i = 0; i < st.PlayerBase.Buildings.Count; i++)
            {
                TextBlock item = new TextBlock();
                item.Name = i.ToString();
                item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Buildings[i].Type, st.PlayerBase.Buildings[i].Life, st.PlayerBase.Buildings[i].DamageTaken, st.PlayerBase.Buildings[i].Location.ToString(), st.PlayerBase.Buildings[i].Complete.ToString());
                stack3.Children.Add(item);
            }
        }

        private void runGame()
        {
            Game g = new Game(new PlayState());
            var st = (PlayState)g.CurrentState;
            var buildings = st.PlayerBase.Buildings;
            var units = st.PlayerBase.Units;
            Console.ReadLine();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)e.OriginalSource;
            int x = Int32.Parse(textBox1.Text);
            int y = Int32.Parse(textBox2.Text);
            OnBuildCommand(btn.Name, new Uwarcraft.Game.Point(x, y));
        }

        public void OnBuildCommand(string type, Uwarcraft.Game.Point coords)
        {
            if (BuildCommand != null)
            {
                BuildCommandEventArgs e = new BuildCommandEventArgs() { Coords = coords, Type = type };
                BuildCommand(this, e);
                var st = (PlayState)g.CurrentState;
                var buildings = st.PlayerBase.Buildings;
                var units = st.PlayerBase.Units;
                stack3.Children.Clear();
                for (int i = 0; i < st.PlayerBase.Buildings.Count; i++)
                {
                    TextBlock item = new TextBlock();
                    item.Name = "b"+i.ToString();
                    item.Text = string.Format("{0} {1} {2} {3} {4}", st.PlayerBase.Buildings[i].Type, st.PlayerBase.Buildings[i].Life, st.PlayerBase.Buildings[i].DamageTaken, st.PlayerBase.Buildings[i].Location.ToString(), st.PlayerBase.Buildings[i].Complete.ToString());
                    stack3.Children.Add(item);
                }
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Map M = new Map();
            M = M.Run(32,32);
            e.Handled = true;            
        }
    }

    //public class BuildCommandEventArgs
    //{
    //    public string type { get; set; }
    //}
}
