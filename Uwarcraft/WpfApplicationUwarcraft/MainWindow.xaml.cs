﻿using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfApplicationUwarcraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
