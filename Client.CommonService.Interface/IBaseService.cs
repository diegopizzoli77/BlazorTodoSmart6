using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> FinalDelete<TKey>(TKey id_dto);
        Task<T> Insert(T item);
        Task<bool> LogicalDelete<TKey>(TKey id_dto);
        Task<T> SelectById<TKey>(TKey id_dto);
        Task<bool> Update(T item);
        Task<IEnumerable<T>> SelectAll();
    }
}
