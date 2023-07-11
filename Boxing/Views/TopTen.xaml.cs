using Boxing.Models;
using Boxing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boxing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopTen : ContentPage
    {
        public TopTen()
        {
            InitializeComponent();
        }

        private void LVPlayer_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as TopTenItem;

            var model = BindingContext as ModelTopTen;

            model?.show(item);
        }
    }
}