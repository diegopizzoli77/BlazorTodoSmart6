using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM.Interface;
using BlazorTodoSmart.Service.Interface;
using Client.MVVM.Common;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.MVVM.CommonInterface.Enum.IViewModelEnum;

namespace BlazorTodoSmart.MVVM
{
    public class ActivityFormViewModel : BaseFormViewModel<ActivityItem>, IActivityFormViewModel
    {
        private IActivityItemService itemService;
        private int idActivity;
        private string description;
        private int idProject = 0;
        private int priority = 0;
        private DateTime? dueDate = null;
        private DateTime? alarm = null;
        private bool isClosed = false;

        public ActivityFormViewModel(IActivityItemService bService) : base(bService)
        {
            itemService = bService;
        }

        public int IdActivity { get => idActivity; set { if (value != idActivity) { idActivity = value; OnPropertyChanged("IdActivity"); } } }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get => description; set { if (value != description) { description = value; OnPropertyChanged("Description"); } } }
        public int IdProject { get => idProject; set { if (value != idProject) { idProject = value; OnPropertyChanged("IdProject"); } } }
        public int Priority { get => priority; set { if (value != priority) { priority = value; OnPropertyChanged("Priority"); } } }
        public DateTime? DueDate { get => dueDate; set { if (value != dueDate) { dueDate = value; OnPropertyChanged("DueDate"); } } }
        public DateTime? Alarm { get => alarm; set { if (value != alarm) { alarm = value; OnPropertyChanged("Alarm"); } } }
        public bool IsClosed { get => isClosed; set { if (value != isClosed) { isClosed = value; OnPropertyChanged("IsClosed"); } } }

        public bool IsSaveButtonEnabled => !string.IsNullOrEmpty(Description);

        #region Overrides

        protected override async Task InitInternalForm(params int[] idparams)
        {
            await base.InitInternalForm(idparams);

            if (idparams[0] != 0)
                ChangeViewState(StateView.Edit);
            else
                ChangeViewState(StateView.Create);

            editContext = new EditContext(currentItem);

            if (!currentItem.DueDate.HasValue)
                currentItem.DueDate = DateTime.Now;

            await base.CopyModelToViewModel(currentItem, this);
        }

        #endregion

        public override Task OnInvalidSubmitHandler(EditContext editContext)
        {
            throw new NotImplementedException();
        }

        public override async Task OnSubmitHandler(EditContext editContext)
        {
            base.IsSaving = true;
            base.IsFormValid = true;
            base.ErrorMessage = string.Empty;
            try
            {
                ActivityItem objToSave = new ActivityItem();
                await base.CopyViewModelToModel(this, objToSave);                

                if (base.IsFormValid)
                {
                    StateView presave = ActualStateView;

                    await base.Save(objToSave);

                    if (presave==StateView.Create)
                    {
                        ChangeViewState(StateView.Create);
                        await InitInternalForm(0);
                    }
                    else
                        ChangeViewState(StateView.Edit);
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                base.IsSaving = false;
            }

        }

        public override Task OnValidSubmitHandler(EditContext editContext)
        {
            throw new NotImplementedException();
        }
    }
}
