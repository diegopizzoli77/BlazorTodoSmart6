using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace Client.MVVM.CommonInterface
{
    public interface IGridViewModel<T>: ICommonListViewModel<T> where T: class
    {
        /// <summary>
        /// Evento che si scatena al binding dei dati con la griglia, compresi filtri e paginazione
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task ReadItems(GridReadEventArgs args);

        /// <summary>
        /// Sorgente dati per la griglia
        /// </summary>
        ObservableCollection<object> GridSource { get; set; }


       void OnRowClickHandler(GridRowClickEventArgs args);
    }
}
