using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Models;
using System.Linq;

namespace TODO.Services
{
    /// <summary>
    /// Implements IDataService<TaskItem> using a default list of Task items;
    /// </summary>
    public class TaskServiceList : IDataService<TaskModel>
    {
        private List<TaskModel> _items;

        public Task<(bool success, string message)> SaveItemsAsync()
        {
            return Task.FromResult((false, "Save not yet implemented"));
        }

        public Task<(bool success, string message)> LoadItemsAsync()
        {
            _items = new List<TaskModel>{
                new TaskModel{description = "Task A"},
                new TaskModel{description = "Task B"},
                new TaskModel{description = "Task C"}
            }; 
            return Task.FromResult((true, "Items loaded to list"));
        }
        
        public Task<List<TaskModel>> GetItemsAsync()
        {
            return Task.FromResult(_items);
        }

        public Task<bool> UpdateItemAsync(TaskModel model)
        {
            _items.RemoveAll(i => i.guid == model.guid);
           _items.Add(model);

           return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(TaskModel model)
        {
            _items.RemoveAll(i => i.guid == model.guid);
            return Task.FromResult(true);
        }

        public Task<bool> CreateItemAsync(TaskModel model)
        {
            _items.Add(model);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Loads first item found based on guid string
        /// If item not found returns null
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>TaskItem</returns>
        public Task<TaskModel> LoadItemAsync(string guid)
        {
            return Task.FromResult(_items.FirstOrDefault(i => i.guid == guid));
        }
    }
}