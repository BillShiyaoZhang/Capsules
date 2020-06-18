using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capsules.Models;

namespace Capsules.Services
{
    public class MockDataStore : IDataStore<Capsule>
    {
        readonly List<Capsule> items;

        public MockDataStore()
        {
            items = new List<Capsule>()
            {
                new Capsule { Title = "First item", Description="This is an item description." },
                new Capsule { Title = "Second item", Description="This is an item description." },
                new Capsule { Title = "Third item", Description="This is an item description." },
                new Capsule { Title = "Fourth item", Description="This is an item description." },
                new Capsule { Title = "Fifth item", Description="This is an item description." },
                new Capsule { Title = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Capsule item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Capsule item)
        {
            var oldItem = items.Where((Capsule arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Capsule arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Capsule> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Capsule>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        Task<IEnumerable<Capsule>> IDataStore<Capsule>.GetItemsAsync(bool isDraft, bool forceRefresh)
        {
            throw new NotImplementedException();
        }
    }
}