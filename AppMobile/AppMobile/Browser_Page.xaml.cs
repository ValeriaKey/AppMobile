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
    public partial class Browser_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Grid gr;
        Entry url;
        ImageButton homeBtn, backBtn, favoriteBtn;
        List<string> urls = new List<string> { "https://tahvel.edu.ee/", "https://moodle.edu.ee/", "https://www.tthk.ee/" };

        public Browser_Page()
        {
            Warning();

            picker = new Picker
            {
                Title = "Favorites",
                BackgroundColor = Color.Lavender,
                WidthRequest = 300
            };

            picker.Items.Add("tahvel.edu.ee");
            picker.Items.Add("moodle.edu.ee");
            picker.Items.Add("tthk.ee");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            // ** BUTTONS **
            // Favorite
            favoriteBtn = new ImageButton()
            {
                Source = "f.png",
                Background = null,
                WidthRequest = 40,
                HeightRequest = 40,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent
            };
            favoriteBtn.Clicked += favoriteBtn_Clicked;
            // Home
            homeBtn = new ImageButton()
            {
                Source = "hb.png",
                Background = null,
                WidthRequest = 40,
                HeightRequest = 40,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent
            };
            homeBtn.Clicked += HomeBtn_Clicked;
            // Back
            backBtn = new ImageButton
            {
                Source = "ba.png",
                WidthRequest = 40,
                HeightRequest = 40,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent
            };
            backBtn.Clicked += BackBtn_Clicked;

            webView = new WebView { 

            };

            // Entry 
            url = new Entry()
            {
                WidthRequest = 180,
                Placeholder = "https://URL",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            url.Completed += Url_Completed;
            // ** LAYOUT OF BUTTONS / ENTRY ** 
            // Grid
            gr = new Grid
            {
                Margin = new Thickness(0, 5, 0, 0),
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                     new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                      new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                      new ColumnDefinition { Width = new GridLength(6, GridUnitType.Star) },
                },
            };
            gr.Children.Add(homeBtn, 0, 0);
            gr.Children.Add(backBtn, 1, 0);
            gr.Children.Add(favoriteBtn, 2, 0);
            gr.Children.Add(url, 3, 0);
            st = new StackLayout
            {
                Children = { gr, picker }
            };
            Content = st;
        }

        void Warning()
        {
            DisplayAlert("Warning!", "Firstly, choose URL from 'Favorites'! \nThank you:) \n// Valeria Novak!", "Let's go!");
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void HomeBtn_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = urls[2] };

        }

        private async void favoriteBtn_Clicked(object sender, EventArgs e)
        {
            if (url.Text != null )
            {
                urls.Add("https://" + url.Text);
                picker.Items.Add(url.Text);
                await DisplayAlert("Favorite Adding", "New favorite URL successfully added", "Okay!");
            } else
            {
                await DisplayAlert("Favorite Adding", "Enter URL, which you wanna add to FAVORITES", "Okay!");
            }
        }

        private void Url_Completed(object sender, EventArgs e)
        {
            var text = "https://" + ((Entry)sender).Text;
            webView.Source = text;
            st.Children.Add(webView);
            // ((Entry)sender).Text = "";
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = urls[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            st.Children.Add(webView);
        }


    }
}