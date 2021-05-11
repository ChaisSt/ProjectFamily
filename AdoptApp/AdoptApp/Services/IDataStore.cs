using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdoptApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool fRefresh = false);

        //Task<bool> AddcaseAsync(T case);
        //Task<bool> UpdatecaseAsync(T case);
        //Task<bool> DeletecaseAsync(string id);
        //Task<T> GetcaseAsync(string id);
        //Task<IEnumerable<T>> GetcasesAsync(bool forceRefresh = false);
    }
}
