using Microsoft.Extensions.DependencyInjection;
using Windows.ApplicationModel.Resources;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

using MicaForEveryone.Interfaces;
using MicaForEveryone.UI;

namespace MicaForEveryone.Views
{
    internal class AddClassRuleDialog : ContentDialog
    {
        private AddClassRuleDialog()
        {
            var resources = ResourceLoader.GetForCurrentView();
            Title = resources.GetString("AddRuleDialog/Title");
            Width = 400;
            Height = 300;

            ViewModel.Title = resources.GetString("AddClassRuleContentDialog/Title");

            var autoSuggestBox = (AutoSuggestBox)XamlReader.Load(@"
<AutoSuggestBox xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                x:Uid='ClassNameSuggestBox'
                HorizontalAlignment='Stretch'
                ItemsSource='{Binding Suggestions}'
                Text='{Binding ClassName, Mode=TwoWay}' />
"); 
            autoSuggestBox.DataContext = ViewModel;
            autoSuggestBox.QuerySubmitted += (sender, args) =>
            {
                ViewModel.PrimaryCommand.Execute(this);
            };
            autoSuggestBox.SuggestionChosen += (sender, args) =>
            {
                ViewModel.ClassName = args.SelectedItem.ToString();
            };
            autoSuggestBox.Loaded += (sender, args) =>
            {
                autoSuggestBox.Focus(FocusState.Programmatic);
            };
            ViewModel.Content = autoSuggestBox;

            ViewModel.IsPrimaryButtonEnabled = true;
            ViewModel.PrimaryButtonContent = resources.GetString("AddButton/Content");
            ViewModel.PrimaryCommandParameter = this;

            ViewModel.IsSecondaryButtonEnabled = true;
            ViewModel.SecondaryButtonContent = resources.GetString("CancelButton/Content");
            ViewModel.SecondaryCommand = CloseDialogCommand;
            ViewModel.SecondaryCommandParameter = this;
        }

        public new IAddClassRuleViewModel ViewModel { get; }
    }
}
