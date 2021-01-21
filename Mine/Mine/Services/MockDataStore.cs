using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hot Sauce", Description="Causes enemy goes blind and misses to attack.", Value = 6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Sticky Noddle", Description="Disables enemy to move.", Value = 4 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pan", Description="Reduces 3 points of health", Value = 8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Mosquito Nose", Description="Makes enemey's skin itches uncontorllably till drops a special weapon to get relief.", Value = 10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Flip Flops", Description="A ranged weapon,it can target anything by 3 blocks away also it will resduce 3 points of health.", Value = 9 },
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}