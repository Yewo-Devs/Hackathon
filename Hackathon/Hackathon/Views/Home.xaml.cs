using Hackathon.Animated_Views;
using Hackathon.Models;
using Hackathon.Views.Onboarding;
using Rg.Plugins.Popup.Services;
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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void ProfileImageButton_Clicked(object sender, EventArgs e)
        {
            int block = Retrieve().block2;
            if(block == 0)
            {
                SerializedData data = Retrieve();
                data.block2 = 1;
                Serialize(data);

                await Navigation.PushAsync(new Names());
            }
            else
            {
                await Navigation.PushAsync(new Profile());
            }
        }
        private async void FavoriteImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Favourites());
        }
        private void MinImageButton_Clicked(object sender, EventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Action(0);
            PopupNavigation.PushAsync(categoryView, true);
        }
        private void EmeImageButton_Clicked(object sender, EventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Action(3);
            PopupNavigation.PushAsync(categoryView, true);
        }
        private void BusImageButton_Clicked(object sender, EventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Action(1);
            PopupNavigation.PushAsync(categoryView, true);
        }
        private void ParaImageButton_Clicked(object sender, EventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Action(2);
            PopupNavigation.PushAsync(categoryView, true);
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new News(), true);
        }
    }
}