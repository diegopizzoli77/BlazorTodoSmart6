using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM.Interface;
using Client.MVVM.CommonInterface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace BlazorTodoSmart.UI.Component
{
    public partial class ActivityMainCalendar
    {
       
        CalendarView selectedView { get; set; } = CalendarView.Month;

        [Parameter]
        public IActivityCalendarViewModel CalendarViewModel { get; set; }

        [Parameter]
        public EventCallback<DateTime> OnCalendarSelectDate { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await CalendarViewModel.LoadAllItems();

            await CalendarViewModel.ValueChanged(CalendarViewModel.SelectedDate);

            await base.OnInitializedAsync();
        }

        private void Navigate(DateTime? inputDate, int inputFilter = 0)
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

        private void OnCellRender(CalendarCellRenderEventArgs args)
        {
            

           args.Class = CalendarViewModel.HasDateEvents(args.Date) ? "hasActivity" : "";

           
        }
    }
}
