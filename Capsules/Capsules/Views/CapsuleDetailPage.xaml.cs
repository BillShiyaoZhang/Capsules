using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Capsules.Models;
using Capsules.ViewModels;

namespace Capsules.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CapsuleDetailPage : ContentPage
    {
        CapsuleDetailViewModel viewModel;

        public CapsuleDetailPage(CapsuleDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CapsuleDetailPage()
        {
            InitializeComponent();

            var item = new Capsule
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new CapsuleDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}