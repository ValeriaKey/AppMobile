using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        Random rnd;

        public Box_Page()
        {
            box = new BoxView
            {
                Color = Color.FromRgb(61, 126, 235),
                CornerRadius = 5,
                WidthRequest = 40,
                HeightRequest = 60,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            StackLayout st = new StackLayout
            {
                Children = { box }
            };

            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            box.Rotation += 25;

            try
            {
                Vibration.Vibrate();
                var dur = TimeSpan.FromSeconds(0.3);
                Vibration.Vibrate(dur);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
