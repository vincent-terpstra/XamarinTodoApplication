using System.Collections.Generic;
using System.Threading.Tasks;

namespace TODO.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAllItemsAsync();
        
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        
        Task<T> GetItemAsync(long id);
    }
}