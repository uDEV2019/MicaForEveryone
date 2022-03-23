using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

using MicaForEveryone.UI.ViewModels;

namespace MicaForEveryone.UI
{
    public sealed partial class SettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        public ISettingsViewModel ViewModel { get; set; }

        private void ListView_Loaded(object sender, RoutedEventArgs args)
        {
            ((ListView)sender).Focus(FocusState.Programmatic);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs args)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }

        private void RulesAppBarButton_PointerEntered(object sender, PointerRoutedEventArgs args)
        {
            AnimatedIcon.SetState((UIElement)sender, "PointerOver");
        }

        private void RulesAppBarButton_PointerPressed(object sender, PointerRoutedEventArgs args)
        {
            AnimatedIcon.SetState((UIElement)sender, "Pressed");
        }

        private void RulesAppBarButton_PointerReleased(object sender, PointerRoutedEventArgs args)
        {
            AnimatedIcon.SetState((UIElement)sender, "Normal");
        }

        private void RulesAppBarButton_PointerExited(object sender, PointerRoutedEventArgs args)
        {
            AnimatedIcon.SetState((UIElement)sender, "Normal");
        }
    }
}
