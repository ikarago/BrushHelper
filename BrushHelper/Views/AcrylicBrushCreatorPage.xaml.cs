using BrushHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace BrushHelper.Views
{
    public sealed partial class AcrylicBrushCreatorPage : Page
    {
        public AcrylicViewModel Brush { get; set; }

        public AcrylicBrushCreatorPage()
        {
            this.InitializeComponent();

            Brush = new AcrylicViewModel { BackgroundSource = AcrylicBackgroundSource.HostBackdrop,
                Opacity = 0.8,
                TintColor = Colors.Black,
                TintOpacity = 0.5};

            var _itemlist = Enum.GetValues(typeof(AcrylicBackgroundSource)).Cast<AcrylicBackgroundSource>();
            cmBackdrop.ItemsSource = _itemlist.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBrushes();
        }

        private void UpdateBrushes()
        {
            MainBrushLight.BackgroundSource = Brush.BackgroundSource;
            MainBrushLight.Opacity = Brush.Opacity;
            MainBrushLight.TintColor = Brush.TintColor;
            MainBrushLight.TintOpacity = Brush.TintOpacity;

            MainBrushDark.BackgroundSource = Brush.BackgroundSource;
            MainBrushDark.Opacity = Brush.Opacity;
            MainBrushDark.TintColor = Brush.TintColor;
            MainBrushDark.TintOpacity = Brush.TintOpacity;

            tblXamlBrush.Text = Brush.XamlBrush;

            // TODO: Continue with this
            if (Brush.BackgroundSource == AcrylicBackgroundSource.Backdrop)
            {
                ImageBrush img = new ImageBrush();
                BitmapImage bitImg = new BitmapImage();
                bitImg.UriSource = new Uri(@"ms-appx:///Assets/Backgrounds/iu.jpg");
                img.ImageSource = bitImg;

                BorderExample.Background = img;
            }
            else
            {
                BorderExample.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UpdateBrushes();
        }

        private void ColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            UpdateBrushes();
        }

        private void cmBackdrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBrushes();
        }
    }
}
