using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GetScrollViewer(ListBoxHomeName);
            scrollViewer.ScrollChanged += OnScrollChanged;
        }
 
        private ScrollViewer GetScrollViewer(DependencyObject dependencyObject)
        {
            var border = VisualTreeHelper.GetChild(dependencyObject, 0);
            return (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
        }
 
        private void OnScrollChanged(object sender, ScrollChangedEventArgs eventArgs)
        {
            var scrollViewer = GetScrollViewer(ListBoxHomeName);
 
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToVerticalOffset(eventArgs.VerticalOffset);
                scrollViewer.ScrollToHorizontalOffset(eventArgs.HorizontalOffset);
            }
        }



#if DEBUG
        private void CreateDummySeason_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DataContext = Helper.CreateSeason();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
#endif
    }
}