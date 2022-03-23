using Microsoft.UI.Xaml;

namespace MicaForEveryone.Interfaces
{
    internal interface IGeneralSettingsViewModel : UI.ViewModels.IGeneralSettingsViewModel
    {
        void Initialize(Window sender);
    }
}
