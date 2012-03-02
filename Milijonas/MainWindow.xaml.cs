using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milijonas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startAdmin(object sender, RoutedEventArgs e)
        {
            new AdminWindow(this).Show();
            this.Hide();

        }

        private void startGame(object sender, RoutedEventArgs e)
        {
           
            GameWindow gameWindow = new GameWindow(this);
            gameWindow.Show(); 
            this.Hide(); // rethink this.

        }


    }
}
