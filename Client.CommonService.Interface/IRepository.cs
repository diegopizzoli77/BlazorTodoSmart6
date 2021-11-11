using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddItem(T item);

        Task UpdateItem(T item);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetItemByKey<TKey>(TKey keysearch);

        Task DeleteItemByKey<TKey>(TKey keysearch);

        Task DeleteAll();

        Task DeleteAllDatabase();


    }
}
