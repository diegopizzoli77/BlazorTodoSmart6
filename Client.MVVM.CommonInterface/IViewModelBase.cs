using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.CommonInterface
{
   public interface IViewModelBase<T> : INotifyPropertyChanged where T : class
    {
        /// <summary>
        /// Imposta o restituisce lo stato di caricamento
        /// </summary>
        public bool IsLoading { get; set; }

        /// <summary>
        /// Imposta o restituisce lo stato di primo caricamento
        /// </summary>
        public bool IsFirstLoad { get; set; }

        /// <summary>
        /// Elemento selezionato
        /// </summary>
        public T CurrentItem { get; set; }

        /// <summary>
        /// Effettua il binding tra viewmodel e il model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> BindViewModelToModel(T model);

        /// <summary>
        /// Effettua il binding tra model e viewmodel
        /// </summary>
        /// <returns></returns>
        Task BindModelToViewModel();
    }
}
