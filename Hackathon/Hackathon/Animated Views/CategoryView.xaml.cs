using Hackathon.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hackathon.Animated_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : PopupPage
    {
        int storeX;

        public string[] Mins = { "Ministry of Health", "Ministry of Education", "Ministry of Youth, Sport and Culture" };
        public string[] MinsImg = { "MOH", "MOE", "MOY" };

        public string[] Bus = { "CEDA", "National Development Bank", "Youth Development Fund" };
        public string[] BusImg = { "CEDA", "NDB", "YDF" };

        public string[] Para = { "Botswana Power Corporation", "Botswana Innovation Hub", "Air Botswana" };
        public string[] ParaImg = { "BPC", "BIH", "AB" };

        public string[] Eme = { "Police", "MRI", "Fire Brigade" };
        public string[] EmeImg = { "Po", "MRI", "FB" };
        public CategoryView()
        {
            InitializeComponent();
        }
        public void Action(int x)
        {
            storeX = x;
            switch (x)
            {
                case 0:
                    for (int i = 0; i < Mins.Length; i++)
                    {
                        main.Children.Add(GetGrid(Mins[i]));
                    }
                    break;
                case 1:
                    for (int i = 0; i < Bus.Length; i++)
                    {
                        main.Children.Add(GetGrid(Bus[i]));
                    }
                    break;
                case 2:
                    for (int i = 0; i < Para.Length; i++)
                    {
                        main.Children.Add(GetGrid(Para[i]));
                    }
                    break;
                case 3:
                    for (int i = 0; i < Eme.Length; i++)
                    {
                        main.Children.Add(GetGrid(Eme[i]));
                    }
                    break;
            }
        }
        Grid GetGrid(string name)
        {
            Grid grid = new Grid();

            grid.Children.Add(GetStackLayout(name));

            Button button = new Button();
            button.BindingContext = name;
            button.BackgroundColor = Color.Transparent;
            button.Clicked += Button_Clicked;

            grid.Children.Add(button);
            return grid;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string t = ((Button)sender).BindingContext as string;
            string img = "";

            //show org
            switch (storeX)
            {
                case 0:
                    for (int i = 0; i < Mins.Length; i++)
                    {
                        if (t == Mins[i])
                            img = MinsImg[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < Bus.Length; i++)
                    {
                        if (t == Bus[i])
                            img = BusImg[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < Para.Length; i++)
                    {
                        if (t == Para[i])
                            img = ParaImg[i];
                    }
                    break;
                case 3:
                    for (int i = 0; i < Eme.Length; i++)
                    {
                        if (t == Eme[i])
                            img = EmeImg[i];
                    }
                    break;
            }
            await Navigation.PushAsync(new MinistryView(img, t));

            //Close this
            PopupNavigation.PopAsync(true);
        }

        StackLayout GetStackLayout(string name)
        {
            StackLayout layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.BackgroundColor = Color.FromHex("#f2f2f2");

            Label label = new Label(){
                FontSize = 20,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10,0,0,0),
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            label.Text = name;

            Image image = new Image()
            {
                Source = "follow.png",
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.End
            };

            layout.Children.Add(label);
            layout.Children.Add(image);

            return layout;
        }
    }
}