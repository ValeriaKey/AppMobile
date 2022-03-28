
using System;
using Xamarin.Forms;

namespace AppMobile
{
    public partial class MainPage : ContentPage
    {
        Button box_btn, entry_btn, timer_btn, date_btn, slider_btn, rgb_btn, frame_btn, img_btn, ttt_btn;
        public MainPage()
        {

            // BoxView

            box_btn = new Button
            {
                Text = "BoxView",
                BackgroundColor = Color.White
            };

            box_btn.Clicked += Start_Pages;

            entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.White
            };

            entry_btn.Clicked += Start_Pages;

            // Timer

            timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.White
            };

            timer_btn.Clicked += Start_Pages;

            date_btn = new Button
            {
                Text = "Date/Time",
                BackgroundColor = Color.White
            };

            date_btn.Clicked += Start_Pages;

            // Slider

            slider_btn = new Button
            {
                Text = "Slider",
                BackgroundColor = Color.White
            };

            slider_btn.Clicked += Start_Pages;

            // RGB Color

            rgb_btn = new Button
            {
                Text = "RGB Color",
                BackgroundColor = Color.White
            };

            rgb_btn.Clicked += Start_Pages;

            // Frame

            frame_btn = new Button
            {
                Text = "Frame - Grid",
                BackgroundColor = Color.White
            };

            frame_btn.Clicked += Start_Pages;

            // Image

            img_btn = new Button
            {
                Text = "Image",
                BackgroundColor = Color.White
            };

            img_btn.Clicked += Start_Pages;
            // Tic Tac Toe

            ttt_btn = new Button
            {
                Text = "Tic Tac Toe",
                BackgroundColor = Color.White
            };

            ttt_btn.Clicked += Start_Pages;

            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn, timer_btn, date_btn, slider_btn, rgb_btn, frame_btn, img_btn, ttt_btn }
            };

            st.BackgroundColor = Color.Cyan;
            Content = st;

            
        }

        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (sender == date_btn)
            {
                await Navigation.PushAsync(new Data_Page());
            }
            else if (sender == entry_btn)
            {
                await Navigation.PushAsync(new Entry_Page());
            }
            else if (sender == box_btn)
            {
                await Navigation.PushAsync(new Box_Page());
            }
            else if (sender == timer_btn)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
            else if (sender == slider_btn)
            {
                await Navigation.PushAsync(new Stp_sl_Page());

            }
            else if (sender == rgb_btn)
            {
                await Navigation.PushAsync(new RGB_Color());
            }
            else if (sender == frame_btn)
            {
                await Navigation.PushAsync(new Frame_Page());
            }
            else if (sender == img_btn)
            {
                await Navigation.PushAsync(new Image_Page());
            }
            else if (sender == ttt_btn)
            {
                await Navigation.PushAsync(new Tic_Tac_Toe());
            }
        }
    }
}

