using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MicaForEveryone
{
    public partial class App : Application
    {
        public static IServiceProvider CurrentContainer => ((App)Current).Container;

        public App()
        {
            InitializeComponent();
        }

        public IServiceProvider Container { get; private set; }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
        }
    }
}
