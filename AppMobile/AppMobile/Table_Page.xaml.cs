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
    public partial class Table_Page : ContentPage
    {
        TableView tableview;
        SwitchCell sc;
        ImageCell ic;
        TableSection tableSection;
        public Table_Page()
        {
            tableview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sistamine")
                {
                    new TableSection("Pohiandmed:")
                    {
                        new EntryCell
                        {
                            Label = "Nimi:",
                            Placeholder = "Sisesta oma nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label = "Telefon:",
                            Placeholder = "Sisesta tel.number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email:",
                            Placeholder = "Sisesta email",
                            Keyboard = Keyboard.Email
                        },

                    },
                }
            };
            Content = tableview;
        }

            private void Sc_OnChanged(object sender, ToggledEventArgs e)
            {
                if (e.Value)
                {
                    tableSection.Title = "Photo";
                    tableSection.Add(ic);
                    sc.Text = "Hide";

                }
                else
                {
                    tableSection.Title = "Photo";
                    tableSection.Remove(ic);
                    sc.Text = "Show again";
                }
            }
        }
    }