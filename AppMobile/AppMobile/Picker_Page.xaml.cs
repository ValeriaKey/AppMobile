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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        ImageButton homeBtn, backBtn;
        /*string[] lehed = new string[4]
        {
            "https://tahvel.edu.ee/#/",
            "https://moodle.edu.ee/",
            "https://tthk.ee/",
            "https://www.google.com/"
        };*/
        
        List<string> lehed = new List<string> { "https://tahvel.edu.ee/#/", "https://moodle.edu.ee/", "https://tthk.ee/", "https://www.google.com/" };
        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };

            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Google");

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            frame = new Frame
            {
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 20,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            // ENTRY FOR URL

            Entry entry = new Entry
            {
                Placeholder = "URL",
                Keyboard = Keyboard.Url
            };
            entry.Completed += Entry_Completed;


            // "HOME" BUTTON
            homeBtn = new ImageButton
            {
                Source = "home.png",
                HeightRequest = 50,
                WidthRequest = 50,

            };
            homeBtn.Clicked += HomeBtn_Clicked;
            // "GOBACK" BUTTON
            backBtn = new ImageButton
            {
                Source = "backarrow.png",
                HeightRequest = 50,
                WidthRequest = 50,
            };
            backBtn.Clicked += BackBtn_Clicked;
            st = new StackLayout { Children = { picker, frame, homeBtn, backBtn, entry } };
            frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }


            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = e.ToString() },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            if(webView.CanGoBack)
            {
                webView.GoBack();
            };
            
        }

        private void HomeBtn_Clicked(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView {
                Source = new UrlWebViewSource { Url = lehed[3] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }
    }
}