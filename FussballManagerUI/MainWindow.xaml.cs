using System.Windows;
using FussballManagerLogic;

namespace FussballManagerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // DbConnector db = new DbConnector();
            
        }

        private void currentSeason_Click(object pSender, RoutedEventArgs pE)
        {
            frmContent.Navigate(new CurrentSeasonPage(DataContext));
        }
    }
}
