using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Data_Page : ContentPage 
    {
        DatePicker dp;
        Label lbl;
        Label crntTime;
        TimePicker tp;
        Button btn;
        public Data_Page()
        {
            lbl = new Label
            {

                Text = "Vali mingi kuupäev või kellaaeg",
                BackgroundColor = Color.BurlyWood
            };

            crntTime = new Label
            {
                Text = "Praegu on: " + DateTime.Now.ToString("D"),
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
        };
            dp = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-5),
                MaximumDate = DateTime.Now.AddDays(15)
            };
            dp.DateSelected += Dp_DateSelected;

            tp = new TimePicker
            {
                Time = new TimeSpan(14, 45, 00)
            };
            tp.PropertyChanged += Tp_PropertyChanged;

            btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.White
            };

            btn.Clicked += Time_Timer;
            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = {dp, tp, lbl, btn, crntTime}
            };
            AbsoluteLayout.SetLayoutBounds(crntTime, new Rectangle(0.1, 0, 300, 70));
            AbsoluteLayout.SetLayoutFlags(crntTime, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1,0.1, 300, 70));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.1, 0.3, 300, 70));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1,0.5, 300, 70));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(btn, new Rectangle(0.1,0.7, 300, 70));
            AbsoluteLayout.SetLayoutFlags(btn, AbsoluteLayoutFlags.PositionProportional);
            Content = abs; 
        }

        private async void Time_Timer(object sender, EventArgs e)
        {
            /*if( NewDate.ToString("D") == DateTime.Now.ToString("G"))
            {
                await Navigation.PushAsync(new Box_Page());
            }*/
        }

        private void Tp_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud: " + dp.Date.ToString("D") + " " + tp.Time.ToString("T");
            Timer_start();

        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Oli valitud: " + e.NewDate.ToString("D") + " " + tp.Time.ToString("T");
            Timer_start();
        }

        private async void Timer_start()
        {
            var time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
            while(time!= 0)
            {
                await Task.Delay(1000);
                lbl.Text = time.ToString();
                time = (int)(tp.Time.Seconds - DateTime.Now.TimeOfDay.TotalSeconds);
                if(time == 0)
                {
                    lbl.BackgroundColor = Color.Red;
                    var dur = TimeSpan.FromSeconds(0.3);
                    Vibration.Vibrate(dur);
                    break;
                }
            }
        }
    }
}