using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Capsules.Models;

namespace Capsules.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewCapsulePage : ContentPage
    {
        public Capsule Item { get; set; }
        public TimeSpan DueTime { get; set; }

        public NewCapsulePage()
        {
            InitializeComponent();

            Item = new Capsule();

            DueTime = new TimeSpan();


            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item.Due = Item.Due.Date + DueTime;
            if (Item.IsSealable)
            {
                Item.IsDraft = false;
                MessagingCenter.Send(this, "AddSealedItem", Item);
                await Navigation.PopModalAsync();
            }
            else
            {
                // TODO: pop up window to ask if store as draft
                bool store = await DisplayAlert("Save as draft?",
                    "There are details not filled. Do you want to save as draft instead?",
                    "Yes", "No, discard");
                if (store)
                {
                    Item.IsDraft = true;
                    MessagingCenter.Send(this, "AddDraftItem", Item);
                }
                await Navigation.PopModalAsync();
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}