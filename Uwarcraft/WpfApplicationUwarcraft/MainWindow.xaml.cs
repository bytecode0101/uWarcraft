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
using Uwarcraft.Units;
using Uwarcraft.Game.StateMachine;

namespace WpfApplicationUwarcraft
{
    public delegate void BuildCommandEventHandler(object button, BuildCommandEventArgs type);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event BuildCommandEventHandler BuildCommand;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("starting thread");
            Thread states = new Thread(new ThreadStart(runGame));
            Uwarcraft.Units.UIBLC denumiri = new Uwarcraft.Units.UIBLC();
          denumiri= XMLWork.XMLDeserialization();
            int xx = denumiri.buildingTypes.Length;
            int yy = denumiri.unitTypes.Length;
            for (int i = 0; i < xx; i++)
            {
                Button button1 = new Button();
                button1.Content = denumiri.buildingTypes[i];
                button1.Name = denumiri.buildingTypes[i].ToUpper();
                stack1.Children.Add(button1);
            }

            for (int i = 0; i < yy; i++)
            {
                Button button1 = new Button();
                button1.Content = denumiri.unitTypes[i];
                button1.Name = denumiri.unitTypes[i].ToUpper();
                stack2.Children.Add(button1);
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
    }

    public class BuildCommandEventArgs
    {
        public string type { get; set; }
    }
}
