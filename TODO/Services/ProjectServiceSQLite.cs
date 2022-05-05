using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;
using TODO.Models;
using Xamarin.Forms;

namespace TODO.Services;

public class ProjectServiceSQLite : IDataService<ProjectModel>
{
    private readonly SQLiteAsyncConnection _database;
    
    public ProjectServiceSQLite()
    {
        _database = DependencyService.Get<SQLiteAsyncConnection>();
    }

    public Task<List<ProjectModel>> GetAllItemsAsync()
    {
        return _database.Table<ProjectModel>().ToListAsync();
    }

    public Task<List<ProjectModel>> GetFilteredItemsAsync(Expression<Func<ProjectModel, bool>> filter)
    {
        return _database.Table<ProjectModel>().Where(filter).ToListAsync();
    }

    public Task<int> UpdateItemAsync(ProjectModel item)
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

    public Task<int> DeleteItemAsync(ProjectModel item)
    {
        return _database.DeleteAsync(item);
    }

    public Task<ProjectModel> GetItemAsync(long id)
    {
        return _database.Table<ProjectModel>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
    }
}