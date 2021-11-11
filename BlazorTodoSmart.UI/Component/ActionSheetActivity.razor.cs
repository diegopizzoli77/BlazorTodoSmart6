using BlazorTodoSmart.MVVM.Interface;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.UI.Component
{
    public partial class ActionSheetActivity
    {
        [Parameter]
        public string ID { get; set; } = "actionSheetForm";

        [Parameter]
        public IActivityFormViewModel activityViewModel { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public int IDActivity { get; set; } = 0;

        [Parameter]
        public EventCallback OnActivityAdded { get; set; }

        protected override async Task OnInitializedAsync()
        {


            await activityViewModel.InitForm(IDActivity);

            await base.OnInitializedAsync();


        }

        private async Task AddActivity()
        {
            await activityViewModel.OnSubmitHandler(activityViewModel.editContext);
            await OnActivityAdded.InvokeAsync();
        }
    }
}
