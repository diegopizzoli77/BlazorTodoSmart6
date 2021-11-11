using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.CommonInterface
{
    public interface IObservableListViewModel<T>:IViewModelBase<T> where T : class
    {
        /// <summary>
        /// Sorgente dati per elementi di tipo  Observable
        /// </summary>
        ObservableCollection<T> ListViewSource { get; set; }

        /// <summary>
        /// Loading data without filters
        /// </summary>
        /// <returns></returns>
        Task LoadAllItems();

        /// <summary>
        /// Refresh data
        /// </summary>
        /// <returns></returns>
        Task RefreshData();
    }
}
