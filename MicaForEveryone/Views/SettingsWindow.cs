using System;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Resources;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;

using MicaForEveryone.Interfaces;
using MicaForEveryone.Models;
using MicaForEveryone.UI;
using MicaForEveryone.Win32;
using MicaForEveryone.Win32.PInvoke;

namespace MicaForEveryone.Views
{
    internal class SettingsWindow : Win32.Window
    {
        private SettingsWindow()
        {
            Style = WindowStyles.WS_OVERLAPPEDWINDOW & ~WindowStyles.WS_MAXIMIZEBOX;
            Width = 1000;
            Height = 700;

            var resources = ResourceLoader.GetForCurrentView();
            Title = resources.GetString("SettingsTitle/Text");
        }

        private ISettingsViewModel ViewModel { get; } =
            App.CurrentContainer.GetService<ISettingsViewModel>();

        public override void Activate()
        {
            base.Activate();

            CenterToWindowScaled(GetDesktopWindow());
            UpdatePosition();

            EnableWindowThemeAttribute(WTNCA.WTNCA_NODRAWCAPTION | WTNCA.WTNCA_NODRAWICON | WTNCA.WTNCA_NOSYSMENU);

            // FIXME: DesktopWindowManager.SetImmersiveDarkMode(Handle, View.ActualTheme == ElementTheme.Dark);
            DesktopWindowManager.EnableMicaIfSupported(Handle);

            ViewModel.Initialize(this);
            ShowWindow();
            SetForegroundWindow();
        }

        private void View_ActualThemeChanged(FrameworkElement sender, object args)
        {
            DesktopWindowManager.SetImmersiveDarkMode(Handle, sender.ActualTheme == ElementTheme.Dark);
        }
    }
}
