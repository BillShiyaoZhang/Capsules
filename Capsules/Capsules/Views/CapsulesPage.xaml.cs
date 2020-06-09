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
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CapsulesPage : ContentPage
    {
        CapsulesViewModel viewModel;

        public CapsulesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CapsulesViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Capsule)layout.BindingContext;
            await Navigation.PushAsync(new CapsuleDetailPage(new CapsuleDetailViewModel(item)));
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