using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stp_sl_Page : ContentPage
    {
        Label lbl;
        Stepper stp;
        Slider sl;

        public Stp_sl_Page()
        {
            lbl = new Label
            {
                Text = "Text",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            sl = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                MinimumTrackColor = Color.Blue,
                MaximumTrackColor = Color.Green,
                ThumbColor = Color.White,
            };
            sl.ValueChanged += ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center
            };
            stp.ValueChanged += ValueChanged;
            this.Content = new StackLayout { Children = { lbl, sl, stp } };
        }

        private void ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri väärtus on {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }
    }
}