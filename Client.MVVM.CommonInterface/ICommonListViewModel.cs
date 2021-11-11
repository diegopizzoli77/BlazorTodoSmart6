using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace Client.MVVM.CommonInterface
{
    public interface ICommonListViewModel<T> : IObservableListViewModel<T> where T:class
    {
        int TotalItems { get; set; }

        int PageSize { get; set; }

        List<IFilterDescriptor> FilterDescriptors { get; set; }

        Task RemoveAllFilter();

        Task RemoveFilter(IFilterDescriptor filterToRemove);

        Task AddFilter(IFilterDescriptor filterToAdd);
    }
}
