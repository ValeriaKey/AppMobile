using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    public class Ruhm<K, T> : ObservableCollection<T>
    {
        public K Nimetus { get; private set; }
        public Ruhm(K nimetus, IEnumerable<T> items)
        {
            Nimetus = nimetus;
            foreach (T item in items)
                Items.Add(item);
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List_Page : ContentPage
    {
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        //public List<Telefon> telefons { get; set; }
        public ObservableCollection<Telefon> telefons { get; set; }
        //public ObservableCollection<Ruhm<string, Telefon>> telefonideruhmades { get; set; }

        public List_Page()
        {
            // Simple list
            /* string[] Telefonid = new string[]
             { "iPhone 7", "Samsung Galaxy S8", "Huawei P10", "LG G6" }; */
            /* telefons = new List<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind="349", Pilt="samsung.jpg"},
                new Telefon {Nimetus="iPhone 12 Blue", Tootja="Apple", Hind="1200", Pilt="iph12.jpg"},
                new Telefon {Nimetus="iPhone 12 Red", Tootja="Apple", Hind="1099", Pilt="iph12r.jpg"},
                new Telefon {Nimetus="Mi 9T", Tootja="Samsung", Hind="349", Pilt="mi1.jpg"},
            }; */
            /*
            telefons = new ObservableCollection<Telefon>
            {
                 new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind="349", Pilt="samsung.jpg"},
                new Telefon {Nimetus="iPhone 12 Blue", Tootja="Apple", Hind="1200", Pilt="iph12.jpg"},
                new Telefon {Nimetus="iPhone 12 Red", Tootja="Apple", Hind="1099", Pilt="iph12r.jpg"},
                new Telefon {Nimetus="Mi 9T", Tootja="Samsung", Hind="349", Pilt="mi1.jpg"},
            };
            
            */
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind="349", Pilt="samsung.jpg"},
                new Telefon {Nimetus="iPhone 12 Blue", Tootja="Apple", Hind="1200", Pilt="iph12.jpg"},
                new Telefon {Nimetus="iPhone 12 Red", Tootja="Apple", Hind="1099", Pilt="iph12r.jpg"},
                new Telefon {Nimetus="Mi 9T", Tootja="Samsung", Hind="349", Pilt="mi1.jpg"},
            };

            /*
            var telefonid = new List<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind="349", Pilt="samsung.jpg"},
                new Telefon {Nimetus="iPhone 12 Blue", Tootja="Apple", Hind="1200", Pilt="iph12.jpg"},
                new Telefon {Nimetus="iPhone 12 Red", Tootja="Apple", Hind="1099", Pilt="iph12r.jpg"},
                new Telefon {Nimetus="Mi 9T", Tootja="Xiaomi", Hind="349", Pilt="mi1.jpg"},
                new Telefon {Nimetus="iPhone 12 Black", Tootja="Apple", Hind="999", Pilt="iph12.jpg"},
            };
            var ruhmad = telefonid.GroupBy(p => p.Tootja).Select(g => new Ruhm<string, Telefon>(g.Key,g));
            telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            */


            /* ListView listView = new ListView();
             listView.ItemsSource = phones; */
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            /* list = new ListView
             {
                 ItemsSource = Telefonid
             };*/
            /* list = new ListView
            {
                 HasUnevenRows = true,
                ItemsSource = telefons,
               ItemTemplate = new DataTemplate(() =>
                 {
                     Label nimetus = new Label { Text = "", FontSize = 20 };
                     nimetus.SetBinding(Label.TextProperty, "Nimetus");

                     Label tootja = new Label();
                     tootja.SetBinding(Label.TextProperty, "Tootja");

                     Label hind = new Label();
                     hind.SetBinding(Label.TextProperty, "Hind");

                     Label pilt = new Label();
                     hind.SetBinding(Label.TextProperty, "Pilt");
                     return new ViewCell
                     {
                         View = new StackLayout
                         {
                             Padding = new Thickness(0, 5),
                             Orientation = StackOrientation.Vertical,
                             Children = { nimetus, tootja, hind,pilt }
                         }
                     };
                 }) 
                

            };*/


            /*list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nimetus = new Label { Text = "", FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Tootja");

                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");

                    Label pilt = new Label();
                    pilt.SetBinding(Label.TextProperty, "Pilt");

                    ImageCell imageCell = new ImageCell
                    {
                        TextColor = Color.Red,
                        DetailColor = Color.Green
                    };
                    imageCell.SetBinding(ImageCell.TextColorProperty, "Nimetus");

                    Binding companyBinding = new Binding
                    {
                        Path = "Tootja",
                        StringFormat = "Tore telefon firmalt {0}"
                    };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.DetailProperty, "Pilt");
                    return imageCell;

                }) 
        }; */
            /*
             list = new ListView
             {
                 SeparatorColor = Color.Orange,
                 Header = "Telefonid ryhmades:",
                 Footer = DateTime.Now.ToString("T"),
                 HasUnevenRows = true,
                ItemsSource = telefonid,
                 ItemTemplate = new DataTemplate(() =>
                 {
                     //Label nimetus = new Label { FontSize = 20 };
                     //nimetus.SetBinding(Label.TextProperty, "Nimetus");

                     //Label tootja = new Label();
                     //tootja.SetBinding(Label.TextProperty, "Tootja");

                     //Label hind = new Label();
                     //hind.SetBinding(Label.TextProperty, "Hind");

                     ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                     imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                     Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                     imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                     imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                     return imageCell;
                 }) 
                 GroupHeaderTemplate = new DataTemplate(() =>
                 {
                     Label tootja = new Label();
                     tootja.SetBinding(Label.TextProperty, "Nimetus");

                     return new ViewCell
                     {
                         View = new StackLayout
                         {
                             Padding = new Thickness(0, 5),
                             Orientation = StackOrientation.Vertical,
                             Children = { tootja }
                         }
                     };
                 }),
                 ItemTemplate = new DataTemplate(() =>
                 {
                     Label nimetus = new Label { FontSize = 20 };
                     nimetus.SetBinding(Label.TextProperty, "Nimetus");
                     Label hind = new Label();
                     hind.SetBinding(Label.TextProperty, "Hind");
                     return new ViewCell
                     {
                         View = new StackLayout
                         {
                             Padding = new Thickness(0, 5),
                             Orientation = StackOrientation.Vertical,
                             Children = { nimetus,hind }
                         }
                     };
                 })
             }; 
            */
            /*
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Telefonid rühmades",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefonideruhmades,
                IsGroupingEnabled = true,
                //ItemsSource = telefons,
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Nimetus");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { tootja }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { nimetus, hind }
                        }
                    };

                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            */
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    //Label nimetus = new Label { FontSize = 20 };
                    //nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    //Label tootja = new Label();
                    //tootja.SetBinding(Label.TextProperty, "Tootja");

                    //Label hind = new Label();
                    //hind.SetBinding(Label.TextProperty, "Hind");

                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            //list.ItemSelected += List_ItemSelected;
            list.ItemTapped += List_ItemTapped;

            lisa = new Button { Text = "Lisa felefon" };
            lisa.Clicked += Lisa_Clicked;
            kustuta = new Button { Text = "Kustuta telefon" };
            kustuta.Clicked += Kustuta_Clicked;

            this.Content = new StackLayout { Children = {lbl_list, list, lisa, kustuta}};
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if(phone != null)
            {
                telefons.Remove(phone);
               list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
          telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = "1" });
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if(selectedPhone != null)
            {
                await DisplayAlert("Model:", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "Super!:)");
            }
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                lbl_list.Text = e.SelectedItem.ToString();
            }
        }
        public class Telefon
        {
            public string Nimetus { get; set; }
            public string Tootja { get; set; }
            public string Hind { get; set; }
            public string Pilt { get; set; }

        }
        
    }
}