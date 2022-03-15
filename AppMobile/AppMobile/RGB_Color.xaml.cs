using PowerArgs;
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
    public partial class RGB_Color : ContentPage
    {
        Label hLabel, redLabel, blueLabel, greenLabel;
        Slider redSlider, blueSlider, greenSlider;
        BoxView box;
        Button btnRandomColor;
        Random rnd;

        public RGB_Color()
        {
            // Heading
            hLabel = new Label
            {
                Text = " RGB Color [SLIDERS] ",
                HorizontalOptions = LayoutOptions.Center,
                Margin = 5,
                TextTransform = TextTransform.Uppercase,
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
            };

            // Box
            box = new BoxView
            {
                CornerRadius = 10,
                WidthRequest = 400,
                HeightRequest = 400,
                Margin = 10,
               HorizontalOptions = LayoutOptions.Center,
            };
            // Red Color
            redLabel = new Label
            {
                Text = "Red Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,
            };
            redSlider.ValueChanged += ValueChanged;
            // Blue Color
            blueLabel = new Label
            {
                Text = "Blue Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,
            };
            blueSlider.ValueChanged += ValueChanged;
            // Green Color
            greenLabel = new Label
            {
                Text = "Green Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,
            };
            greenSlider.ValueChanged += ValueChanged;
            // Button for generate random color
            btnRandomColor = new Button
            {
                Text = "Random Color"
            };
            btnRandomColor.Clicked += BtnRandomColor_Clicked; ;


            this.Content = new StackLayout { Children = { hLabel, box, redLabel, redSlider, greenLabel, greenSlider, blueLabel, blueSlider, btnRandomColor } };
        }

        private void BtnRandomColor_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255),
                                      rnd.Next(0, 255),
                                      rnd.Next(0, 255));
        }

        private void ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }

            box.Color = Color.FromRgb((int)redSlider.Value,
                                          (int)greenSlider.Value,
                                          (int)blueSlider.Value);
        }
    }
}