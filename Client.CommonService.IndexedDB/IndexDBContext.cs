using Client.CommonService.Interface;
using DnetIndexedDb;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService.IndexedDB
{
    public class IndexDBContext<T> : IndexedDbInterop, IRepository<T> where T : class
    {
        private string objectStoreKey = typeof(T).Name.ToPlural();

        public IndexDBContext(IJSRuntime jsRuntime, IndexedDbOptions<IndexDBContext<T>> indexedDbDatabaseOptions) : base(jsRuntime, indexedDbDatabaseOptions)
        {
        }

        public async Task<T> AddItem(T item)
        {
            var openResult = await OpenIndexedDb();

            var result = await this.AddItems<T>(objectStoreKey, new List<T> { item });
           
            return item;
        }

        public async Task<T> GetItemByKey<TKey>(TKey keysearch)
        {
            var openResult = await OpenIndexedDb();
            return await this.GetByKey<TKey, T>(objectStoreKey, keysearch);
        }

        public async Task DeleteItemByKey<TKey>(TKey keysearch)
        {
            var openResult = await OpenIndexedDb();
            await this.DeleteByKey<TKey>(objectStoreKey, keysearch);
        }

        public async Task DeleteAll()
        {
            await this.DeleteAll(objectStoreKey);
        }

        public async Task DeleteAllDatabase()
        {
            await this.DeleteAllDatabase();
        }

        public async Task UpdateItem(T item)
        {
            await this.UpdateItems<T>(objectStoreKey, new List<T> { item });
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var openResult = await OpenIndexedDb();

            return await this.GetAll<T>(objectStoreKey);
        }
    }
}
