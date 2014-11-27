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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using TDDD49_Chess.AI;
using TDDD49_Chess.Game;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.View;
using TDDD49_Chess.View.Persistor;

namespace TDDD49_Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //This is where the view is hooked up with the game.
            //Adds the human player
        }
    }
}
