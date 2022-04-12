using System.Collections.Generic;
using System.Threading.Tasks;

namespace TODO.Services
{
    public interface IDataService<T>
    {
        Task<(bool success, string message)> LoadItemsAsync();
        Task<(bool success, string message)> SaveItemsAsync();
        Task<List<T>> GetItemsAsync();
        
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<bool> CreateItemAsync(T item);
        Task<T> LoadItemAsync(string guid);
    }
}