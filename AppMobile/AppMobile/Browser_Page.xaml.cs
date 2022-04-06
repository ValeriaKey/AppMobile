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
        ImageButton homeBtn, backBtn;
        Entry url;
        WebView webView;
        StackLayout st;
        public List<String> urls = new List<string> { };
        public Browser_Page()
        {
            // Buttons 
            backBtn = new ImageButton()
            {
                Source = "ba.png",
                WidthRequest = 40, HeightRequest = 40,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent

            };
            backBtn.Clicked += BackBtn_Clicked;
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
            // Entry 
            url = new Entry()
            {
                WidthRequest = 180,
                Placeholder = "https://URL",
                VerticalOptions= LayoutOptions.Start,
                HorizontalOptions= LayoutOptions.FillAndExpand
            };
            url.Completed += Url_Completed;
            //Grid 
            Grid gr;
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
                      new ColumnDefinition { Width = new GridLength(7, GridUnitType.Star) },
                },
            };
            gr.Children.Add(homeBtn, 0, 0);
            gr.Children.Add(backBtn, 1, 0);
            gr.Children.Add(url, 2, 0);

            // Webview

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://google.com" },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st = new StackLayout { Children = { gr,webView } };
            Content = st;
            

        }

        private void Url_Completed(object sender, EventArgs e)
        {

            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            
            var text = "https://" + ((Entry)sender).Text;

            webView.Source = new UrlWebViewSource
            {
                Url = text,
            };
            st.Children.Add(webView);
            ((Entry)sender).Text = "";
            urls.Add(text);

          
        }

        private void HomeBtn_Clicked(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }

            webView.Source = new UrlWebViewSource
            {
                Url = "https://google.com",
            };
            st.Children.Add(webView);
        }

        void BackBtn_Clicked(object sender, EventArgs e)
        {

            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            /* NOT WORKING 
            if (webView.CanGoBack)
            {
                webView.GoBack();
            } 
            */

            
            Int32 length;
            int currentCount = urls.Count;
            int notMore = urls.Count;
            if (urls.Count > 1)
            {
                for (int i = currentCount; (currentCount + 1) > notMore; currentCount--)
                {
                    int currentWebSite = (currentCount - 1);
                    int backWebSite = currentCount - 2;
                    webView.Source = new UrlWebViewSource
                    {
                        Url = urls[backWebSite]
                    };
                    st.Children.Add(webView);
                    urls.Remove(urls[backWebSite]);
                }
            }
            else
            {
                webView.Source = new UrlWebViewSource
                {
                    Url = "https://google.com",
                };
                st.Children.Add(webView);
            }
            
        }
    }
}