using BlazorTodoSmart.MVVM.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace BlazorTodoSmart.UI.Component
{
    public partial class ActivityList
    {
        [Parameter]
        public IActivityListViewModel activityViewModel { get; set; }

        [Parameter]
        public int IDProject { get; set; } = 0;

        [Parameter]
        public EventCallback<int> SelectedItemCallBack { get; set; }

        [Parameter]
        public EventCallback<int> CheckedItemCallBack { get; set; }

        [Parameter]
        public DateTime? FilterDate { get; set; }

        [Parameter]
        public int FilterMode { get; set; } = 0;

        private void MyOnRowClick(GridRowClickEventArgs args)
        {
            activityViewModel.OnRowClickHandler(args);
            SelectedItemCallBack.InvokeAsync(activityViewModel.IDActivitySelected);
        }

        protected override void OnInitialized()
        {
            activityViewModel.IDProject = IDProject;
            activityViewModel.FilterDate = FilterDate;
            activityViewModel.FilterMode = FilterMode;
            base.OnInitialized();
        }
    }
}
