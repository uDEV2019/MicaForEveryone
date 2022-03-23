using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

using MicaForEveryone.UI;
using MicaForEveryone.UI.ViewModels;
using MicaForEveryone.Win32;
using MicaForEveryone.Win32.PInvoke;

namespace MicaForEveryone.Views
{
    public class ContentDialog : Dialog
    {
        protected static RelayCommand<Dialog> CloseDialogCommand { get; } =
            new RelayCommand<Dialog>(dialog => dialog.Close());

        private static COLORREF GetResourceColor(ResourceDictionary resources, string name)
        {
            var result = ((SolidColorBrush)resources[name]).Color;
            return new COLORREF
            {
                A = (byte)(255 - result.A),
                R = result.R,
                G = result.G,
                B = result.B,
            };
        }

        protected ContentDialog()
        {
            ViewModel.IsPrimaryButtonEnabled = true;
            ViewModel.PrimaryCommand = CloseDialogCommand;
            ViewModel.PrimaryCommandParameter = this;

            var resources = ResourceLoader.GetForCurrentView();
            ViewModel.PrimaryButtonContent = resources.GetString("OkButton/Text");
        }

        public IContentDialogViewModel ViewModel { get; } =
            App.CurrentContainer.GetRequiredService<IContentDialogViewModel>();

        public override void Activate()
        {
            base.Activate();
            SetTitlebarColor();
        }

        private void View_ActualThemeChanged(FrameworkElement sender, object args)
        {
            SetTitlebarColor();
        }

        private void SetTitlebarColor()
        {
            var resources = Microsoft.UI.Xaml.Application.Current.Resources;
            var background = GetResourceColor(resources, "ContentDialogBackground");
            var topOverlay = GetResourceColor(resources, "ContentDialogTopOverlay");
            var captionBackground = background.Blend(topOverlay);

            var foreground = GetResourceColor(resources, "ContentDialogForeground");
            var captionTextColor = captionBackground.Blend(foreground);

            captionBackground.A = 0;
            captionTextColor.A = 0;

            DesktopWindowManager.SetCaptionColor(Handle, captionBackground);
            DesktopWindowManager.SetCaptionTextColor(Handle, captionTextColor);
        }
    }
}
