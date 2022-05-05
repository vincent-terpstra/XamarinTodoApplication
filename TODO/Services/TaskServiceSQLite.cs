using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;
using TODO.Models;
using Xamarin.Forms;

namespace TODO.Services;

public class TaskServiceSQLite : IDataService<TaskModel>
{
    private readonly SQLiteAsyncConnection _database;
    
    public TaskServiceSQLite()
    {
        _database = DependencyService.Get<SQLiteAsyncConnection>();
    }

    public Task<List<TaskModel>> GetAllItemsAsync()
    {
        return _database.Table<TaskModel>().ToListAsync();
    }

    public Task<List<TaskModel>> GetFilteredItemsAsync(Expression<Func<TaskModel, bool>> filter)
    {
        return _database.Table<TaskModel>().Where(filter).ToListAsync();
    }

    public Task<int> UpdateItemAsync(TaskModel item)
    {
        if (item.Id != 0)
        {
            return _database.UpdateAsync(item);
        }
        else
        {
            return _database.InsertAsync(item);
        }
    }

    public Task<int> DeleteItemAsync(TaskModel item)
    {
        return _database.DeleteAsync(item);
    }

    public Task<TaskModel> GetItemAsync(long id)
    {
        return _database.Table<TaskModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }
}