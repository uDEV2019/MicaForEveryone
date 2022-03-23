using Windows.ApplicationModel.Resources;

namespace MicaForEveryone.Views
{
    public class ErrorDialog : ContentDialog
    {
        public ErrorDialog()
        {
            var resources = ResourceLoader.GetForCurrentView();
            Title = resources.GetString("AppName");
        }
    }
}
