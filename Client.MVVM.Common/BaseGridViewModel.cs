using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace Client.MVVM.Common
{
    public class BaseGridViewModel<T> : BaseCommonListViewModel<T>, IGridViewModel<T> where T : class
    {

        private ObservableCollection<object> gridSource = new ObservableCollection<object>(new List<T>());

        public ObservableCollection<object> GridSource { get => gridSource; set {
                if (value != gridSource)
                {
                    gridSource = value;
                    OnPropertyChanged("GridSource");
                }
            } }

        public BaseGridViewModel(IBaseService<T> bService) : base(bService)
        {
            IsFirstLoad = true;
        }

        public override async Task RefreshData()
        {
            IsLoading = true;
            GridSource.Clear();
            GridSource = new ObservableCollection<object>(new List<T>());


           await Task.Run(()=> OnPropertyChanged("GridSource"));
            IsLoading = false;
        }

        public virtual async Task ReadItems(GridReadEventArgs args)
        {
            IsLoading = true;
            try
            {
                var res = await getAllItems();

                if (filterDescriptors != null)
                {
                    args.Request.Filters = filterDescriptors;
                }

                IQueryable<T> queriableData = res.AsQueryable();

                DataSourceRequest req = args.Request;

                DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(req);

                IEnumerable<object> datares; ;

                if (req.Groups.Count > 0)
                {
                    datares = processedData.Data.Cast<AggregateFunctionsGroup>().Cast<object>().ToList();
                }
                else
                {
                    datares = processedData.Data.Cast<T>();
                }


                TotalItems = processedData.Total;

                GridSource = new ObservableCollection<object>(datares.Cast<object>().ToList());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsFirstLoad = false;
                IsLoading = false;
            }
        }

        public virtual void OnRowClickHandler(GridRowClickEventArgs args)
        {
            if (args != null && args.Item!=null)
                CurrentItem = args.Item as T;
        }
    }
}
