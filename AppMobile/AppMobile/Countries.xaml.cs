﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Countries : ContentPage
    {
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        Entry country, capital, population, imageURL;
        public ObservableCollection<Country> countries { get; set; }
        public class Country
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public string Population { get; set; }
            public string Flag { get; set; }

        }
        public Countries()
        {
        
        countries = new ObservableCollection<Country>
            {
                new Country {Name="Estonia", Capital="Tallinn", Population="1,331m", Flag="estoniafl.png"},
                new Country {Name="Latvia", Capital="Riga", Population="1,902m", Flag="latviafl.png"},
                new Country {Name="Lithuania", Capital="Vilnius", Population="2,795m", Flag="lithfl.png"},
            };
            lbl_list = new Label
            {
                Text = "Countries",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = countries,
                ItemTemplate = new DataTemplate(() =>
                { 

                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding companyBinding = new Binding { Path = "Capital", StringFormat = "Super Capital of Country: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Flag");
                    return imageCell;
                })


            };
            country = new Entry
            {
                Placeholder = "Country"
            };
            capital = new Entry
            {
                Placeholder = "Capital"
            };
            population = new Entry
            {
                Placeholder = "Population"
            };
            imageURL = new Entry
            {
                Placeholder = "ImageURL"
            };
            lisa = new Button { Text = "Add Contry" };
            lisa.Clicked += Lisa_Clicked;
            kustuta = new Button { Text = "Delete Country" };
            kustuta.Clicked += Kustuta_Clicked;

            this.Content = new StackLayout { Children = { lbl_list, list,country, capital, population, imageURL, lisa, kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Country country = list.SelectedItem as Country;
            if (country != null)
            {
                countries.Remove(country);
                list.SelectedItem = null;
            }
        }
        private void Lisa_Clicked(object sender, EventArgs e)
        {
            countries.Add(new Country { Name = country.Text, Capital = capital.Text, Population = population.Text, Flag = imageURL.Text });
        }
    }
}