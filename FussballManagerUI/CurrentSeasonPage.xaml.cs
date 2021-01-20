using System;
using System.Windows.Controls;
using FussballManagerTest;
namespace FussballManagerUI
{
    /// <summary>
    /// Interaction logic for CurrentSeasonPage.xaml
    /// </summary>
    public partial class CurrentSeasonPage : Page
    {
        public CurrentSeasonPage(Object Context )
        {
            InitializeComponent();
            DataContext = Context;
        }
#if DEBUG
        private void CreateDummySeason_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DataContext = Helper.CreateSeason();

        }
#endif
    }
}
