using Hackathon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hackathon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        string[] messages = {"Use the search bar to quickly find services", 
            "Ministries are located under their respective categories", 
            "Services you use most often are stored under favorites on the nav bar" };

        string[] images = {"SS1.png", "SS2.png", "SS3.png" };
        public Splash()
        {
            InitializeComponent();
            Method();
        }

        private void Method()
        {
            int x = 0;
            x = Retrieve().block;

            if(x == 0)
            {
                SerializedData data = Retrieve();
                data.block = 1;

                Serialize(data);

                Display("Welcome!", "SS1.png");
            }
            else
            {
                int y = 0;
                y = new Random().Next(0, messages.Length);

                Display(messages[y], images[y]);
            }
        }
        void Display(string message, string pic)
        {
            label.Text = message;
            image.Source = pic;

            if(message != "Welcome!")
            {
                label.FontSize = 10;
                //label.HorizontalOptions = LayoutOptions.Start;
            }
            Fade();
        }

        async void Fade()
        {
            main.Opacity = 0;
            await main.FadeTo(1, 2000);
            Application.Current.MainPage = new NavigationPage(new Home());
        }
        void Serialize(SerializedData data)
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HackathonData.txt");

            var save = data;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Create(savePath))
            {
                binaryFormatter.Serialize(fileStream, save);
            }
        }
        SerializedData Retrieve()
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HackathonData.txt");
            SerializedData load = new SerializedData();

            if (File.Exists(savePath))
            {
                var binaryFormatter = new BinaryFormatter();
                using (var fileStream = File.Open(savePath, FileMode.Open))
                {
                    load = (SerializedData)binaryFormatter.Deserialize(fileStream);
                }
            }

            return load;
        }
    }
}