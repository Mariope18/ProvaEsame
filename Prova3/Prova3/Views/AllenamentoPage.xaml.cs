using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prova3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllenamentoPage : ContentPage
    {
        public AllenamentoPage()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailPageAllenamento());
        }
    }
}