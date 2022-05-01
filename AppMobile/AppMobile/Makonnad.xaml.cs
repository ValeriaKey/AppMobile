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
    public partial class Makonnad : ContentPage
    {
        Label title, nameOfCounty;
        Picker picker, picker2;
        Image img;
        Entry search;
        StackLayout st;
        public Makonnad()
        {
            title = new Label
            {
                Text = "Maakond:",
                FontSize = 20,

            };
            picker = new Picker
            {
                Title = "Pealinn"
            };

            picker.Items.Add("Tallinn");
            picker.Items.Add("Narva");
            picker.Items.Add("Tartu");
            picker.Items.Add("Pärnu");

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            picker2 = new Picker
            {
                Title = "Maakond"
            };

            picker2.Items.Add("Harjumaa");
            picker2.Items.Add("Ida-Virumaa");
            picker2.Items.Add("Tartumaa");
            picker2.Items.Add("Pärnumaa");

            picker2.SelectedIndexChanged += Picker2_SelectedIndexChanged;

            nameOfCounty = new Label
            {
                Text = "Te olete valitud: - ...",
                FontSize = 16,

            };
            img = new Image
            {
                Source = "test.jpg"
            };
            search = new Entry
            {
                Placeholder = "Maakond"
            };
            search.Completed += Search_Completed;
            st = new StackLayout { Children = { title,picker, picker2, nameOfCounty, img,search } };
            Content = st;

        }

        private void Search_Completed(object sender, EventArgs e)
        {
            if(((Entry)sender).Text == "Harjumaa")
            {
                picker.SelectedIndex = 0;
                picker2.SelectedIndex = 0;
                nameOfCounty.Text = "Te olete valitud - Harjumaa/Tallinn";
                img.Source = "tallinn2.jpg";
            } else if (((Entry)sender).Text == "Ida-Virumaa")
            {
                picker.SelectedIndex = 1;
                picker2.SelectedIndex = 1;
                nameOfCounty.Text = "Te olete valitud - Ida-Virumaa/Narva";
                img.Source = "narva1.jpg";
            }
            else if (((Entry)sender).Text == "Pärnumaa")
            {
                picker.SelectedIndex = 3;
                picker2.SelectedIndex = 3;
                nameOfCounty.Text = "Te olete valitud - Pärnumaa/Pärnu";
                img.Source = "pärnu4.jpg";
            }
            else if (((Entry)sender).Text == "Tartumaa")
            {
                picker.SelectedIndex = 2;
                picker2.SelectedIndex = 2;
                nameOfCounty.Text = "Te olete valitud - Tartumaa/Tartu";
                img.Source = "tartu3.jpg";
            } else
            {
                DisplayAlert("Not Found!", "Write in 'Enter' - Harjumaa/Ida-Virumaa/Tartumaa/Pärnumaa or choose from Picker \nThank you:) \n// Valeria Novak!", "Okay!");
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            for(int i = 0; i > 4; i++)
            {
                if (picker.SelectedIndex == i) {
                    picker2.SelectedIndex = i;
                }

            }
           */
           if(picker.SelectedIndex == 0)
            {
                picker2.SelectedIndex = 0;
                nameOfCounty.Text = "Te olete valitud - Harjumaa/Tallinn";
                img.Source = "tallinn2.jpg";
            }
           else if(picker.SelectedIndex == 1)
            {
                picker2.SelectedIndex = 1;
                nameOfCounty.Text = "Te olete valitud - Ida-Virumaa/Narva";
                img.Source = "narva1.jpg";
            }
            else if (picker.SelectedIndex == 2)
            {
                picker2.SelectedIndex = 2;
                nameOfCounty.Text = "Te olete valitud - Tartumaa/Tartu";
                img.Source = "tartu3.jpg";
            }
            else if (picker.SelectedIndex == 3)
            {
                picker2.SelectedIndex = 3;
                nameOfCounty.Text = "Te olete valitud - Pärnumaa/Pärnu";
                img.Source = "parnu4.jpg";
            }
        }
        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (picker2.SelectedIndex == 0)
            {
                picker.SelectedIndex = 0;
            }
            else if (picker2.SelectedIndex == 1)
            {
                picker.SelectedIndex = 1;
            }
            else if (picker2.SelectedIndex == 2)
            {
                picker.SelectedIndex = 2;
            }
            else if (picker2.SelectedIndex == 3)
            {
                picker.SelectedIndex = 3;
            }

        }
    }
}