using BlazorTodoSmart.Models;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM.Interface
{
    public interface IActivitySummaryViewModel: IObservableListViewModel<ActivitySummaryGroup>
    {
        public int NumItemInbox { get; set; }

        public int NumItemToday { get; set; }

        public int NumItemUpcoming { get; set; }
    }
}
