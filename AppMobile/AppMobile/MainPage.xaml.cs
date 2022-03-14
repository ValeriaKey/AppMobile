
using System;
using Xamarin.Forms;

namespace AppMobile
{
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                Button box_btn = new Button
                {
                    Text = "BoxView",
                    BackgroundColor = Color.White
                };

                box_btn.Clicked += Box_btn_Clicked;

                Button entry_btn = new Button
                {
                    Text = "Entry",
                    BackgroundColor = Color.White
                };

                entry_btn.Clicked += Entry_btn_Clicked;
                
                Button timer_btn = new Button
                {
                    Text = "Timer",
                    BackgroundColor = Color.White
                };

                timer_btn.Clicked += Timer_btn_Clicked; 

            StackLayout st = new StackLayout
                {
                    Children = { box_btn, entry_btn, timer_btn }
                };

                st.BackgroundColor = Color.Cyan;
                Content = st;
            }

            private async void Entry_btn_Clicked(object sender, System.EventArgs e)
            {
                await Navigation.PushAsync(new Entry_Page());
            }

            private async void Box_btn_Clicked(object sender, System.EventArgs e)
            {
                await Navigation.PushAsync(new Box_Page());
            }
            private async void Timer_btn_Clicked(object sender, System.EventArgs e)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
    }
    }

