using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hackathon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinistryView : ContentPage
    {
        public MinistryView(string src, string name)
        {
            image.Source = src;
            title.Text = name;
            InitializeComponent();
        }
    }
}