using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using TODO.Models;

namespace TODO.Services;

public class TaskServiceSQLite : IDataService<TaskModel>
{
    private readonly SQLiteAsyncConnection _database;
    
    public TaskServiceSQLite()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Notes.db3");
        
        _database = new SQLiteAsyncConnection(path);
        _database.CreateTableAsync<TaskModel>().Wait();
    }

    public Task<List<TaskModel>> GetAllItemsAsync()
    {
        return _database.Table<TaskModel>().ToListAsync();
    }

    public Task<int> UpdateItemAsync(TaskModel item)
    {
        if (item.ID != 0)
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
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
    }
}