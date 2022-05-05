using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAllItemsAsync();
        Task<List<T>> GetFilteredItemsAsync(Expression<Func<T, bool>> filter);
        
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        
        Task<T> GetItemAsync(long id);
    }
}