using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Objects;

namespace TODO.Services
{
    public interface IDataService<T>
    {
        Task<Result> LoadItemsAsync();
        Task<Result> SaveItemsAsync();
        Task<Result<List<T>>> GetAllItemsAsync();
        
        Task<Result> UpdateItemAsync(T item);
        Task<Result> DeleteItemAsync(string guid);
        Task<Result> CreateItemAsync(T item);
        Task<Result<T>> GetItemAsync(string guid);
    }
}