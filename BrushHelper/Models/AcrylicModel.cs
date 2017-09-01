using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace BrushHelper.Models
{
    public class AcrylicModel
    {
        public AcrylicBackgroundSource BackgroundSource { get; set; }
        public double Opacity { get; set; }
        public Color TintColor { get; set; }
        public double TintOpacity { get; set; }
        //public string FallbackColor { get; set; }
    }
}
