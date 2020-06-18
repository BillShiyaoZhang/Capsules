using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Capsules.Models;
using Capsules.Views;

namespace Capsules.ViewModels
{
    public class DraftsViewModel : BaseViewModel
    {
        public ObservableCollection<Capsule> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public DraftsViewModel()
        {
            Title = "Drafts";
            Items = new ObservableCollection<Capsule>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewCapsulePage, Capsule>(this, "AddDraftItem", async (obj, item) =>
            {
                var newItem = item as Capsule;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var draftItems = await DataStore.GetItemsAsync(true, false);
                foreach (var item in draftItems)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
