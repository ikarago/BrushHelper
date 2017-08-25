using BrushHelper.Models;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI;

namespace BrushHelper.ViewModels
{
    public class AcrylicViewModel : NotificationBase<AcrylicModel>
    {
        private AcrylicModel _brush;

        public AcrylicViewModel()
        {
            _brush = new AcrylicModel();

            // Hack for setting content to not break all this shit
            //BackgroundSource = "HostBackdrop";
            //TintColor = "{StaticResource SystemChromeAltHighColor}";
            //TintOpacity = 0.8;
            //FallbackColor = "{StaticResource SystemChromeMediumColor}";
        }

        public AcrylicBackgroundSource BackgroundSource
        {
            get { return This.BackgroundSource; }
            set { SetProperty(This.BackgroundSource, value, () => This.BackgroundSource = value); }
        }

        public double Opacity
        {
            get { return This.Opacity; }
            set
            {
                value = Math.Round(value, 1);
                SetProperty(This.Opacity, value, () => This.Opacity = value);
            }
        }

        public Color TintColor
        {
            get { return This.TintColor; }
            set { SetProperty(This.TintColor, value, () => This.TintColor = value); }
        }

        public double TintOpacity
        {
            get { return This.TintOpacity; }
            set
            {
                value = Math.Round(value, 1);
                SetProperty(This.TintOpacity, value, () => This.TintOpacity = value);
            }
        }

        public string XamlBrush
        {
            get
            {
                StringBuilder brushString = new StringBuilder();
                brushString.Append("<AcrylicBrush ");
                brushString.Append("BackgroundSource='" + This.BackgroundSource + "' ");
                brushString.Append("Opacity='" + This.Opacity + "' ");
                brushString.Append("TintColor='" + This.TintColor + "' ");
                brushString.Append("TintOpacity='" + This.TintOpacity + "'");
                brushString.Append("/>");

                return brushString.ToString();
            }
        }

        //public string FallbackColor
        //{
        //    get { return This.FallbackColor; }
        //    set { SetProperty(This.FallbackColor, value, () => This.FallbackColor = value); }
        //}


        public void CopyBrushToClipboard()
        {
            DataPackage data = new DataPackage();
            data.RequestedOperation = DataPackageOperation.Copy;
            data.SetText(XamlBrush);
            Clipboard.SetContent(data);
        } 
    }
}
