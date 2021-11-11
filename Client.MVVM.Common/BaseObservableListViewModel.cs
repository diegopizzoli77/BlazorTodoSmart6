using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.Common
{
    public class BaseObservableListViewModel<T> : BaseViewModel<T>, IObservableListViewModel<T> where T : class
    {

        protected ObservableCollection<T> listViewSource = new ObservableCollection<T>(new List<T>());

        public BaseObservableListViewModel(IBaseService<T> bService) : base(bService)
        {
            IsFirstLoad = true;
        }


        public ObservableCollection<T> ListViewSource { get => listViewSource;
            set
            {
                if (value != listViewSource)
                {
                    listViewSource = value;
                    OnPropertyChanged("ListViewSource");
                }
            }
        }

        public virtual async Task LoadAllItems()
        {
            IsLoading = true;
            try
            {
                var res = await getAllItems();

                ListViewSource = new ObservableCollection<T>(res);
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

        protected virtual async Task<IEnumerable<T>> getAllItems()
        {
            return await baseService.SelectAll();
        }

        public virtual async Task RefreshData()
        {
            await LoadAllItems();
        }
    }
}
