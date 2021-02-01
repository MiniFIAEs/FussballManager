using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FussballManagerUI
{
    public class ScrollSyncBehavior : Behavior<ListBox>
    {
        public ListBox Second
        {
            get { return (ListBox) GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        public static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(ListBox), typeof(ScrollSyncBehavior), new PropertyMetadata());

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            var scrollViewer = GetScrollViewer(AssociatedObject);
            scrollViewer.ScrollChanged -= OnScrollChanged;
            AssociatedObject.Loaded -= OnLoaded;

            base.OnDetaching();
        }

        private void OnLoaded(object sender, RoutedEventArgs eventArgs)
        {
            var scrollViewer = GetScrollViewer(AssociatedObject);
            scrollViewer.ScrollChanged += OnScrollChanged;
        }

        private ScrollViewer GetScrollViewer(DependencyObject dependencyObject)
        {
            var border = VisualTreeHelper.GetChild(dependencyObject, 0);
            return (ScrollViewer) VisualTreeHelper.GetChild(border, 0);
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs eventArgs)
        {
            var scrollViewer = GetScrollViewer(Second);

            if (scrollViewer != null)
            {
                scrollViewer.ScrollToVerticalOffset(eventArgs.VerticalOffset);
                scrollViewer.ScrollToHorizontalOffset(eventArgs.HorizontalOffset);
            }
        }
    }
}
