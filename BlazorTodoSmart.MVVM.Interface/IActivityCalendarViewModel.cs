using BlazorTodoSmart.Models;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM.Interface
{
    public interface IActivityCalendarViewModel : ICalendarViewModel<ActivityItem>
    {
        public List<DateTime> CarouselData { get; set; }

        public Task PageChangedHandler(int newPage);

        public bool HasDateEvents(DateTime inputDate);

    }
}
