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
    

    public partial class Horoskop : ContentPage
    {
        Label title, name, desc;
        Image img;
        DatePicker dp;
        StackLayout st;
        Entry search;
        public Horoskop()
        {
            title = new Label
            {
                Text = "Horoskop",
                FontSize = 24,
                TextColor = Color.Black

            };

            dp = new DatePicker
            {
                Format = "M"
            };
            dp.DateSelected += Dp_DateSelected;
            img = new Image
            {
                Source = "",
                WidthRequest = 50,
                HeightRequest = 50

            };
            name = new Label
            {
                Text = "",
                FontSize = 18
            };
            desc = new Label
            {
                Text = ""
            };

            search = new Entry
            {
                Placeholder = "Zodiac Sign"
            };
            search.Completed += Search_Completed;
            st = new StackLayout { Children = { title, search, dp,img, name,desc } };
            st.Padding = new Thickness(20, 10, 20, 10);
            Content = st;

        }

        private void Search_Completed(object sender, EventArgs e)
        {
            if (((Entry)sender).Text == "Goat-Horned")
            {
                name.Text = "Goat-Horned";
                desc.Text = "What is the most valuable resource? For Capricorn, the answer is clear: Time. Capricorn is climbing the mountain straight to the top and knows that patience, perseverance, and dedication is the only way to scale. The last earth sign of the zodiac, Capricorn, is represented by the sea-goat, a mythological creature with the body of a goat and the tail of a fish. Accordingly, Capricorns are skilled at navigating both the material and emotional realms.";
                img.Source = "gh.png";
            }
            else if (((Entry)sender).Text == "The Water-Bearer")
            {

                name.Text = "The Water-Bearer";
                desc.Text = "Despite the 'aqua' in its name, Aquarius is actually the last air sign of the zodiac. Innovative, progressive, and shamelessly revolutionary, Aquarius is represented by the water bearer, the mystical healer who bestows water, or life, upon the land. Accordingly, Aquarius is the most humanitarian astrological sign. At the end of the day, Aquarius is dedicated to making the world a better place. ";
                img.Source = "wb.png";
            }
            else if (((Entry)sender).Text == "The Fishes")
            {

                name.Text = "The Fishes";
                desc.Text = "If you looked up the word 'psychic'' in the dictionary, there would definitely be a picture of Pisces next to it. Pisces is the most intuitive, sensitive, and empathetic sign of the entire zodiac — and that’s because it’s the last of the last. As the final sign, Pisces has absorbed every lesson — the joys and the pain, the hopes and the fears — learned by all of the other signs. It's symbolized by two fish swimming in opposite directions, representing the constant division of Pisces' attention between fantasy and reality.";
                img.Source = "fishes.png";
            }
            else if (((Entry)sender).Text == "The Ram")
            {

                name.Text = "The Ram";
                desc.Text = "The first sign of the zodiac, Aries loves to be number one. Naturally, this dynamic fire sign is no stranger to competition. Bold and ambitious, Aries dives headfirst into even the most challenging situations—and they'll make sure they always come out on top!";
                img.Source = "ram.png";
            }
            else if (((Entry)sender).Text == "The Bull")
            {

                name.Text = "The Bull";
                desc.Text = "What sign is more likely to take a six-hour bath, followed by a luxurious Swedish massage and decadent dessert spread? Why Taurus, of course! Taurus is an earth sign represented by the bull. Like their celestial spirit animal, Taureans enjoy relaxing in serene, bucolic environments surrounded by soft sounds, soothing aromas, and succulent flavors.";
                img.Source = "bull.png";

            }
            else if (((Entry)sender).Text == "The Twins")
            {

                name.Text = "The Twins";
                desc.Text = "Have you ever been so busy that you wished you could clone yourself just to get everything done? That's the Gemini experience in a nutshell. Spontaneous, playful, and adorably erratic, Gemini is driven by its insatiable curiosity. Appropriately symbolized by the celestial twins, this air sign was interested in so many pursuits that it had to double itself.";
                img.Source = "twins.png";
            }
            else if (((Entry)sender).Text == "The Crab")
            {

                name.Text = "The Crab";
                desc.Text = "Represented by the crab, Cancer seamlessly weaves between the sea and shore representing Cancer’s ability to exist in both emotional and material realms. Cancers are highly intuitive and their psychic abilities manifest in tangible spaces. But—just like the hard-shelled crustaceans—this water sign is willing to do whatever it takes to protect itself emotionally. In order to get to know this sign, you're going to need to establish trust!";
                img.Source = "cancer.png";
            }
            else if (((Entry)sender).Text == "The Lion")
            {

                name.Text = "The Lion";
                desc.Text = "Roll out the red carpet because Leo has arrived. Passionate, loyal, and infamously dramatic, Leo is represented by the lion and these spirited fire signs are the kings and queens of the celestial jungle. They're delighted to embrace their royal status: Vivacious, theatrical, and fiery, Leos love to bask in the spotlight and celebrate… well, themselves.";
                img.Source = "leo.png";
            }
            else if (((Entry)sender).Text == "The Maiden")
            {

                name.Text = "The Maiden";
                desc.Text = "You know the expression, 'if you want something done, give it to a busy person?' Well, that definitely is the Virgo anthem. Virgos are logical, practical, and systematic in their approach to life. Virgo is an earth sign historically represented by the goddess of wheat and agriculture, an association that speaks to Virgo's deep-rooted presence in the material world. This earth sign is a perfectionist at heart and isn’t afraid to improve skills through diligent and consistent practice.";
                img.Source = "virg.png";
            }
            else if (((Entry)sender).Text == "The Scales")
            {

                name.Text = "The Scales";
                desc.Text = "Balance, harmony, and justice define Libra energy. As a cardinal air sign, Libra is represented by the scales (interestingly, the only inanimate object of the zodiac), an association that reflects Libra's fixation on establishing equilibrium. Libra is obsessed with symmetry and strives to create equilibrium in all areas of life — especially when it comes to matters of the heart.";
                img.Source = "scla.png";
            }
            else if (((Entry)sender).Text == "The (Centaur) Archer")
            {

                name.Text = "The (Centaur) Archer";
                desc.Text = "Elusive and mysterious, Scorpio is one of the most misunderstood signs of the zodiac. Scorpio is a water sign that uses emotional energy as fuel, cultivating powerful wisdom through both the physical and unseen realms. In fact, Scorpio derives its extraordinary courage from its psychic abilities, which is what makes this sign one of the most complicated, dynamic signs of the zodiac.";
                img.Source = "arrower.png";
            }
            else if (((Entry)sender).Text == "The Scorpion")
            {

                name.Text = "The Scorpion";
                desc.Text = "Oh, the places Sagittarius goes! But… actually. This fire sign knows no bounds. Represented by the archer, Sagittarians are always on a quest for knowledge. The last fire sign of the zodiac, Sagittarius launches its many pursuits like blazing arrows, chasing after geographical, intellectual, and spiritual adventures.";
                img.Source = "scorp.png";
            }
            else
            {
                DisplayAlert("Not Found!", "You can find: \n 1.Goat-Horned \n 2.The Water-Bearer \n 3.The Fishes \n 4.The Ram \n 5.The Bull \n 6.The Twins \n 7.The Crab \n 8.The Lion \n 9.The Maiden \n 10.The Scales \n11.The (Centaur) Archer \n. 12.The Scorpion", "Okay!");

            }
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;
            if (m == 1 && d <= 20 || m == 12 && d >= 22)
            {
                name.Text = "Goat-Horned";
                desc.Text = "What is the most valuable resource? For Capricorn, the answer is clear: Time. Capricorn is climbing the mountain straight to the top and knows that patience, perseverance, and dedication is the only way to scale. The last earth sign of the zodiac, Capricorn, is represented by the sea-goat, a mythological creature with the body of a goat and the tail of a fish. Accordingly, Capricorns are skilled at navigating both the material and emotional realms.";
                img.Source = "gh.png";
            }
            else if (m == 1 && d <= 31 || m == 2 && d <= 19)
            {

                name.Text = "The Water-Bearer";
                desc.Text = "Despite the 'aqua' in its name, Aquarius is actually the last air sign of the zodiac. Innovative, progressive, and shamelessly revolutionary, Aquarius is represented by the water bearer, the mystical healer who bestows water, or life, upon the land. Accordingly, Aquarius is the most humanitarian astrological sign. At the end of the day, Aquarius is dedicated to making the world a better place. ";
                img.Source = "wb.png";
            }
            else if (m == 2 && d <= 28 || m == 3 && d <= 20)
            {

                name.Text = "The Fishes";
                desc.Text = "If you looked up the word 'psychic'' in the dictionary, there would definitely be a picture of Pisces next to it. Pisces is the most intuitive, sensitive, and empathetic sign of the entire zodiac — and that’s because it’s the last of the last. As the final sign, Pisces has absorbed every lesson — the joys and the pain, the hopes and the fears — learned by all of the other signs. It's symbolized by two fish swimming in opposite directions, representing the constant division of Pisces' attention between fantasy and reality.";
                img.Source = "fishes.png";
            }
            else if (m == 3 && d <= 21 || m == 4 && d <= 20)
            {

                name.Text = "The Ram";
                desc.Text = "The first sign of the zodiac, Aries loves to be number one. Naturally, this dynamic fire sign is no stranger to competition. Bold and ambitious, Aries dives headfirst into even the most challenging situations—and they'll make sure they always come out on top!";
                img.Source = "ram.png"; 
            }
            else if (m == 4 && d <= 31 || m == 5 && d <= 21)
            {

                name.Text = "The Bull";
                desc.Text = "What sign is more likely to take a six-hour bath, followed by a luxurious Swedish massage and decadent dessert spread? Why Taurus, of course! Taurus is an earth sign represented by the bull. Like their celestial spirit animal, Taureans enjoy relaxing in serene, bucolic environments surrounded by soft sounds, soothing aromas, and succulent flavors.";
                img.Source = "bull.png";

            }
            else if (m == 5 && d <= 31 || m == 6 && d <= 21)
            {

                name.Text = "The Twins";
                desc.Text = "Have you ever been so busy that you wished you could clone yourself just to get everything done? That's the Gemini experience in a nutshell. Spontaneous, playful, and adorably erratic, Gemini is driven by its insatiable curiosity. Appropriately symbolized by the celestial twins, this air sign was interested in so many pursuits that it had to double itself.";
                img.Source = "twins.png"; 
            }
            else if (m == 6 && d <= 31 || m == 7 && d <= 22)
            {

                name.Text = "The Crab";
                desc.Text = "Represented by the crab, Cancer seamlessly weaves between the sea and shore representing Cancer’s ability to exist in both emotional and material realms. Cancers are highly intuitive and their psychic abilities manifest in tangible spaces. But—just like the hard-shelled crustaceans—this water sign is willing to do whatever it takes to protect itself emotionally. In order to get to know this sign, you're going to need to establish trust!";
                img.Source = "cancer.png";
            }
            else if (m == 7 && d <= 31 || m == 8 && d <= 21)
            {

                name.Text = "The Lion";
                desc.Text = "Roll out the red carpet because Leo has arrived. Passionate, loyal, and infamously dramatic, Leo is represented by the lion and these spirited fire signs are the kings and queens of the celestial jungle. They're delighted to embrace their royal status: Vivacious, theatrical, and fiery, Leos love to bask in the spotlight and celebrate… well, themselves.";
                img.Source = "leo.png";
            }
            else if (m == 8 && d <= 31 || m == 9 && d <= 23)
            {

                name.Text = "The Maiden";
                desc.Text = "You know the expression, 'if you want something done, give it to a busy person?' Well, that definitely is the Virgo anthem. Virgos are logical, practical, and systematic in their approach to life. Virgo is an earth sign historically represented by the goddess of wheat and agriculture, an association that speaks to Virgo's deep-rooted presence in the material world. This earth sign is a perfectionist at heart and isn’t afraid to improve skills through diligent and consistent practice.";
                img.Source = "virg.png";
            }
            else if (m == 9 && d <= 31 || m == 10 && d <= 23)
            {

                name.Text = "The Scales";
                desc.Text = "Balance, harmony, and justice define Libra energy. As a cardinal air sign, Libra is represented by the scales (interestingly, the only inanimate object of the zodiac), an association that reflects Libra's fixation on establishing equilibrium. Libra is obsessed with symmetry and strives to create equilibrium in all areas of life — especially when it comes to matters of the heart.";
                img.Source = "scla.png";
            }
            else if (m == 10 && d <= 31 || m == 11 && d <= 21)
            {

                name.Text = "The (Centaur) Archer";
                desc.Text = "Elusive and mysterious, Scorpio is one of the most misunderstood signs of the zodiac. Scorpio is a water sign that uses emotional energy as fuel, cultivating powerful wisdom through both the physical and unseen realms. In fact, Scorpio derives its extraordinary courage from its psychic abilities, which is what makes this sign one of the most complicated, dynamic signs of the zodiac.";
                img.Source = "arrower.png"; 
            }
            else if (m == 11 && d <= 31 || m == 12 && d <= 22)
            {

                name.Text = "The Scorpion";
                desc.Text = "Oh, the places Sagittarius goes! But… actually. This fire sign knows no bounds. Represented by the archer, Sagittarians are always on a quest for knowledge. The last fire sign of the zodiac, Sagittarius launches its many pursuits like blazing arrows, chasing after geographical, intellectual, and spiritual adventures.";
                img.Source = "scorp.png"; 
            }

        }
    }
}