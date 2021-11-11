using BlazorTodoSmart.Models;
using Client.MVVM.CommonInterface;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM.Interface
{
    public interface IActivityListViewModel : IGridViewModel<ActivityItem>
    {
        public int IDProject { get; set; }

        public int IDActivitySelected { get; }

        public Task UndoCancelActity(int idactivity);

        public ActivityItem GetActivityByID(int idActivity);

        public DateTime? FilterDate { get; set; }

        public int FilterMode { get; set; } 
    }
}
