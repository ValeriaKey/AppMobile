using Plugin.Messaging;
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
        TableView tableView;
        SwitchCell sc;
        ImageCell ic;
        TableSection photoSection, buttons;
        EntryCell phoneCell, emailCell, textCell;
        Button callBtn, emailBtn, smsBtn;

        public Table_Page()
        {
            sc = new SwitchCell { Text = "Info about me:" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("vn.jpg"),
                Text = "Software Developer.",
                Detail = "Helo, i'm Valeria Novak.\n I'm Frontend Developer:)!"
            };
            photoSection = new TableSection();

            callBtn = new Button {
                Text = "CALL",
                BackgroundColor = Color.Gray,
                TextColor = Color.White 
            };
            callBtn.Clicked += CallBtn_Clicked;

            emailBtn = new Button {
                Text = "E-MAIL", 
                BackgroundColor = Color.Gray, TextColor = Color.White 
            };
            emailBtn.Clicked += EmailBtn_Clicked;


            smsBtn = new Button { 
                Text = "SMS",
                BackgroundColor = Color.Gray,
                TextColor = Color.White 
            };
            smsBtn.Clicked += SmsBtn_Clicked;
            var layout = new StackLayout
            {
                Children = { callBtn, emailBtn, smsBtn },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };

            buttons = new TableSection
            {
                new ViewCell
                {
                  View = layout
                }
            };

            phoneCell = new EntryCell
            {
                Label = "Telephone",
                Placeholder = "Enter telephone number",
                Keyboard = Keyboard.Telephone
            };

            emailCell = new EntryCell
            {
                Label = "E-mail",
                Placeholder = "Enter e-mail",
                Keyboard = Keyboard.Email
            };
            textCell = new EntryCell
            {
                Label = "Text",
                Placeholder = "Text",
                Keyboard = Keyboard.Default
            };


            tableView = new TableView
            {
                Intent = TableIntent.Form, 
                Root = new TableRoot("Data Entering")
                {
                    new TableSection("Data:")
                    {
                        new EntryCell
                        {
                            Label = "Name:",
                            Placeholder = "Name:",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Contacts:")
                    {
                        phoneCell,
                        emailCell,
                        textCell,
                        sc
                    },
                    photoSection,
                    buttons
                }
            };
            Content = tableView;
        }

        private void SmsBtn_Clicked(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms(phoneCell.Text, textCell.Text);
        }

        private void EmailBtn_Clicked(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(emailCell.Text, "Theme Letter", textCell.Text);
            }
        }

        private void CallBtn_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(phoneCell.Text);
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                photoSection.Title = "Photo: ";
                photoSection.Add(ic);
                sc.Text = "Hide";
            }
            else
            {
                photoSection.Title = "";
                photoSection.Remove(ic);
                sc.Text = "Info about me:";
            }
        }
    }
}
