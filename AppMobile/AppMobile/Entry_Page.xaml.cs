﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entry_Page : ContentPage
    {
        Label lbl;
        Editor editor;

        public Entry_Page()
        {
            lbl = new Label
            {
                Text = "Pealkiri",
                TextColor = Color.Red
            };

            editor = new Editor
            {
                Placeholder = "Sisesta tekst",
                TextColor = Color.Azure,
                BackgroundColor = Color.Green,
                Keyboard = Keyboard.Email
            };

            editor.TextChanged += Editor_TextChanged;
            StackLayout st = new StackLayout { Children = { lbl, editor } };
            Content = st;
        }

        int i = 0;

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            editor.TextChanged -= Editor_TextChanged;
            char k = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (k == 'T')
            {
                i++;
                lbl.Text = k.ToString() + ": " + i + " korda oli sisestatud";
            }

            editor.TextChanged += Editor_TextChanged;
        }
    }
}