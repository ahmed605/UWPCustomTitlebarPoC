using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CustomTitlebarPoC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage : Page
    {
        public BlankPage()
        {
            this.InitializeComponent();

            this.Loaded += BlankPage_Loaded;
        }

        private async void BlankPage_Loaded(object sender, RoutedEventArgs e)
        {
            Frame appWindowContentFrame = new Frame();

            AppWindow appWindow = await AppWindow.TryCreateAsync();
            appWindow.TitleBar.SetPreferredVisibility(AppWindowTitleBarVisibility.AlwaysHidden);

            appWindowContentFrame.Navigate(typeof(MainPage));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);

            await appWindow.TryShowAsync();
            ((MainPage)appWindowContentFrame.Content).window = appWindow;
            ((MainPage)appWindowContentFrame.Content).SetTitleBar();

            await ApplicationView.GetForCurrentView().TryConsolidateAsync();
        }
    }
}
