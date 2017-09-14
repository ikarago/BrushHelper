using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BrushHelper.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FrameNormalBrushPage.Navigate(typeof(Views.NormalBrushPage));
            FrameAcrylicBrushPage.Navigate(typeof(Views.AcrylicBrushPage));
            FrameAcrylicBrushMakerPage.Navigate(typeof(Views.AcrylicBrushCreatorPage));
        }

        private async void cbtnAbout_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog openChangelogDialog = new ContentDialog()
            {
                Title = "Brush Helper",
                Content = "v" + GetVersion() + " by Ikarago",
                PrimaryButtonText = "Close"
            };

            ContentDialogResult result = await openChangelogDialog.ShowAsync();
        }

        public static string GetVersion()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;
            string versionNumber = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            return versionNumber;
        }
    }
}
