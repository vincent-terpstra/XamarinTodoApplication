﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Models;
using System.Linq;
using TODO.Objects;

namespace TODO.Services
{
    /// <summary>
    /// Implements IDataService : TaskModel using a default list of Task items;
    /// </summary>
    public class TaskServiceList : IDataService<TaskModel>
    {
        private List<TaskModel> _items;

        public Task<Result> SaveItemsAsync()
        {
            return Task.FromResult(new Result("Save not yet implemented"));
        }

        public Task<Result> LoadItemsAsync()
        {
            _items = new List<TaskModel>{
                new TaskModel{Description = "Task A"},
                new TaskModel{Description = "Task B"},
                new TaskModel{Description = "Task C"}
            }; 
            return Task.FromResult(new Result());
        }
        
        public Task<Result<List<TaskModel>>> GetAllItemsAsync()
        {
            return Task.FromResult(new Result<List<TaskModel>>(_items));
        }

        public Task<Result> UpdateItemAsync(TaskModel model)
        {
            _items.RemoveAll(i => i.Guid == model.Guid);
           _items.Add(model);

           return Task.FromResult(new Result());
        }

        public Task<Result> DeleteItemAsync(string guid)
        {
            _items.RemoveAll(i => i.Guid == guid);
            return Task.FromResult(new Result());
        }

        public Task<Result> CreateItemAsync(TaskModel model)
        {
            _items.Add(model);
            return Task.FromResult(new Result());
        }

        /// <summary>
        /// Loads first item found based on guid string
        /// If item not found returns null
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>TaskItem</returns>
        public Task<Result<TaskModel>> GetItemAsync(string guid)
        {
            return Task.FromResult(new Result<TaskModel>(_items.FirstOrDefault(i => i.Guid == guid)));
        }
    }
}