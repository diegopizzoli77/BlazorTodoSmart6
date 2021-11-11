using BlazorTodoSmart.MVVM.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.UI.Component
{
    public partial class ActivitySummary
    {
        [Parameter]
        public IActivitySummaryViewModel viewmodel { get; set; }

        protected override Task OnInitializedAsync()
        {
            viewmodel.LoadAllItems();

            return base.OnInitializedAsync();
        }

        private void Navigate(DateTime? inputDate,int inputFilter=0)
        {

            if (inputDate.HasValue)
            {
                var queryParams = new Dictionary<string, string>
                {
                    ["filterDate"] = inputDate.Value.ToString("yyyy/MM/dd HH:mm:ss"),
                    ["filterMode"] = inputFilter.ToString()
                };
                NavManager.NavigateTo(QueryHelpers.AddQueryString("ActivityPageList", queryParams));
            }
            else
                NavManager.NavigateTo("ActivityPageList");


        }

    }
}
