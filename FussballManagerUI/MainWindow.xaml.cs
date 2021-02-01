using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FussballManagerTest;

namespace FussballManagerUI
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

        private void CurrentSeason_Click(object sender, RoutedEventArgs e)
        {
            FrmContent.Navigate(new CurrentSeasonPage(Helper.CreateSeason()));
            //FrmContent.Navigate(new CurrentSeasonPage(DataContext));
        }

#if DEBUG
        private void CreateDummySeason_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = Helper.CreateSeason();
        }
#endif
    }
}
