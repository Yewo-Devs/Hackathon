using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hackathon.Views.Onboarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Names : ContentPage
    {
        public Names()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}