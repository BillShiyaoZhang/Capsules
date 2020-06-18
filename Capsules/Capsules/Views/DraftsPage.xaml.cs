using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Capsules.Models;
using Capsules.Views;
using Capsules.ViewModels;

namespace Capsules.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DraftsPage : ContentPage
    {
        DraftsViewModel viewModel;

        public DraftsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DraftsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Capsule)layout.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new NewCapsulePage()));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewCapsulePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}