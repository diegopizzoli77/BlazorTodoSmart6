using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.MVVM.CommonInterface.Enum.IViewModelEnum;

namespace Client.MVVM.CommonInterface
{
    public interface ICRUDViewModel<T> : IViewModelBase<T> where T:class
    {
        /// <summary>
        /// Imposta e restituisce lo stato della view
        /// </summary>
        public StateView ActualStateView { get; set; }


        /// <summary>
        /// Imposta o restituisce lo stato di salvataggio
        /// </summary>
        public bool IsSaving { get; set; }
       

        /// <summary>
        /// Comando di aggiunta nuovo elemento
        /// </summary>
        /// <returns></returns>
        Task<T> Add();

        /// <summary>
        /// Comando per passage in modifica
        /// </summary>
        /// <returns></returns>
        bool Edit();

        /// <summary>
        /// Comando per annullare
        /// </summary>
        /// <returns></returns>
        bool Cancel();

        /// <summary>
        /// Comando per salvare un elemento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> Save(T item);

        /// <summary>
        /// Comando per cancellare logicamento un elemento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> LogicalDelete(T item);

        /// <summary>
        /// Comando per cancellare fisicamento un elemento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> FinalDelete(T item);

        /// <summary>
        /// Comando per selezionare un elemento per ID
        /// </summary>
        /// <param name="id_dto"></param>
        /// <returns></returns>
        Task<T> SelectById(int id_dto);

        /// <summary>
        /// Comando per gestire e modificare lo stato della vista
        /// </summary>
        /// <param name="newViewState"></param>
        void ChangeViewState(StateView newViewState);
    }
}
