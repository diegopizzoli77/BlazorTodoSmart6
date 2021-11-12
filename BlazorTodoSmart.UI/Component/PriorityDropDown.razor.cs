using BlazorTodoSmart.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.UI.Component
{
    public partial class PriorityDropDown
    {
        [Parameter]
        public int Priority { get; set; } = 0;

        private IEnumerable<PriorityItem> priorityItems = new List<PriorityItem>
        {
            new PriorityItem { Id=0, Description="None", IconName="flag-outline", IconClass=""},
            new PriorityItem { Id=1, Description="Urgent", IconName="flag", IconClass="text-danger"},
             new PriorityItem { Id=2, Description="Medium", IconName="flag", IconClass="text-warning"},
              new PriorityItem { Id=3, Description="Normal", IconName="flag", IconClass="text-success"}
        };

        [Parameter]
        public EventCallback<int> PriorityChanged { get; set; }


        async Task PriorityOnChangeHandler(object theUserInput)
        {
            int valueSel = (int)theUserInput;

            await PriorityChanged.InvokeAsync(valueSel);

        }

    }
}
