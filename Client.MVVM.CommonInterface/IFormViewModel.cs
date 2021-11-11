using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.CommonInterface
{
    public interface IFormViewModel<T> : ICRUDViewModel<T> where T:class
    {
        /// <summary>
        /// Contesto per l'editing
        /// </summary>
        EditContext editContext { get; set; }

        /// <summary>
        /// Indica se la maschera ha passatto i controlli di validazione
        /// </summary>
        bool IsFormValid { get; set; }

        /// <summary>
        /// Indica se la maschera è editabile o in sola lettura
        /// </summary>
        bool IsFormEditable { get; }

        /// <summary>
        /// Stringa con i messaggi di errore
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Inizializza la maschera con i dati filtrati per la chiave in input
        /// </summary>
        /// <param name="ids">Chiavi per caricare i dati iniziali</param>
        /// <returns></returns>
        Task InitForm(params int[] ids);

        /// <summary>
        /// fires when the user clicks on the Submit button in the Form
        /// </summary>
        /// <param name="editContext"></param>
        Task OnSubmitHandler(EditContext editContext);

        /// <summary>
        /// The OnValidSubmit event fires when the form is submitted and there are no validation errors
        /// </summary>
        /// <param name="editContext"></param>
        Task OnValidSubmitHandler(EditContext editContext);

        /// <summary>
        /// The OnInvalidSubmit event fires when there are validation errors in the Form upon its submission
        /// </summary>
        /// <param name="editContext"></param>
        Task OnInvalidSubmitHandler(EditContext editContext);
    }
}
