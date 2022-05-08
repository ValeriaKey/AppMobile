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
    public partial class Ajaplaan : ContentPage
    {
        Label title;
        Image img;
        TimePicker tp;
        public Ajaplaan()
        {
            title = new Label
            {
                Text = "Ajaplaan",
                FontSize = 24,
                TextColor = Color.Black

            };
        }
    }
}