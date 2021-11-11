using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace Client.MVVM.Common
{
    public class BaseCommonListViewModel<T> : BaseObservableListViewModel<T>, ICommonListViewModel<T> where T : class
    {

        private int totalItems = 0;
        private int pageSize = 0;
        protected List<IFilterDescriptor> filterDescriptors;

        public BaseCommonListViewModel(IBaseService<T> bService) : base(bService)
        {
            IsFirstLoad = true;
        }

        public int TotalItems { get => totalItems; set
            {
                if (value != totalItems)
                {
                    totalItems = value;
                    OnPropertyChanged("TotalItems");
                }
            }
        }
        public int PageSize { get => pageSize; set
            {
                if (value != pageSize)
                {
                    pageSize = value;
                    OnPropertyChanged("PageSize");
                }
            }
        }

        public List<IFilterDescriptor> FilterDescriptors { get => filterDescriptors; set => filterDescriptors=value; }

        public async Task AddFilter(IFilterDescriptor filterToAdd)
        {
            await Task.Run(() => { FilterDescriptors.Add(filterToAdd); });
        }

        public async Task RemoveAllFilter()
        {
            await Task.Run(() => { FilterDescriptors.Clear(); });
        }

        public async Task RemoveFilter(IFilterDescriptor filterToRemove)
        {
            await Task.Run(() => { FilterDescriptors.Remove(filterToRemove); });
        }
    }
}
