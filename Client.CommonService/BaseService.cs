using Client.CommonService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService
{
    public class BaseService<T> : IBaseService<T> where T : class
    {

        protected IRepository<T> dbContext = null;

        public BaseService(IRepository<T> repo)
        {
            dbContext = repo;
        }


        public async Task<bool> FinalDelete<TKey>(TKey id_dto)
        {
            await dbContext.DeleteItemByKey(id_dto);
            return true;
        }

        public async Task<T> Insert(T item)
        {
            return await dbContext.AddItem(item);
        }

        public async Task<bool> LogicalDelete<TKey>(TKey id_dto)
        {
            await dbContext.DeleteItemByKey(id_dto);
            return true;
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await dbContext.GetAll();
        }

        public async Task<T> SelectById<Tkey>(Tkey id_dto)
        {
            return await dbContext.GetItemByKey<Tkey>(id_dto);
        }

        public async Task<bool> Update(T item)
        {
            await dbContext.UpdateItem(item);
            return true;
        }
    }
}
