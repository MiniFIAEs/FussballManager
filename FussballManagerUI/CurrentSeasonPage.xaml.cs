using System;
using FussballManagerTest;
namespace FussballManagerUI
{
    /// <summary>
    /// Interaction logic for CurrentSeasonPage.xaml
    /// </summary>
    public partial class CurrentSeasonPage
    {
        public CurrentSeasonPage(Object pContext )
        {
            InitializeComponent();
            DataContext = pContext;
        }
#if DEBUG
        private void CreateDummySeason_Click(object pSender, System.Windows.RoutedEventArgs pE)
        {
            this.DataContext = Helper.CreateSeason();
        }
#endif
    }
}
