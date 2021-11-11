using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.MVVM.CommonInterface.Enum.IViewModelEnum;

namespace Client.MVVM.Common
{
    public abstract class BaseFormViewModel<T> : BaseCRUDViewModel<T>, IFormViewModel<T> where T : class, new()
    {
        #region Private Variables

        private EditContext editcontext;
        private bool isValidForm = true;
        private string errorMessage = string.Empty;

        #endregion


        #region ctor

        public BaseFormViewModel(IBaseService<T> bService) : base(bService)
        {
            IsFirstLoad = true;
            editcontext = new EditContext(new T());
        }

        #endregion

        #region Public Properties

        public EditContext editContext
        {
            get => editcontext;
            set
            {
                if (value != editcontext)
                {
                    editcontext = value;
                    OnPropertyChanged("editContext");
                }
            }
        }
        public bool IsFormValid
        {
            get => isValidForm;
            set
            {
                if (value != isValidForm)
                {
                    isValidForm = value;
                    OnPropertyChanged("IsFormValid");
                }
            }
        }

        public bool IsFormEditable
        {
            get => ActualStateView == StateView.Read ? false : true;
        }
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (value != errorMessage)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }
        #endregion


        protected virtual async Task InitInternalForm(params int[] idparams)
        {
            if (idparams[0] == 0)
                CurrentItem = await Task.Run(() => Add());
            else
            {
                CurrentItem = await SelectById(idparams[0]);
                ChangeViewState(StateView.Edit);
            }
                

            editContext = new EditContext(CurrentItem);
            await base.CopyModelToViewModel(CurrentItem, this);
        }

        public async Task InitForm(params int[] ids)
        {
            IsFirstLoad = true;
            IsLoading = true;
            try
            {
                await InitInternalForm(ids[0]);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);

            }
            finally
            {
                IsFirstLoad = false;
                IsLoading = false;
            }


        }

        public abstract Task OnInvalidSubmitHandler(EditContext editContext);
        public abstract Task OnSubmitHandler(EditContext editContext);
        public abstract Task OnValidSubmitHandler(EditContext editContext);
    }
}
