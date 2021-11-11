using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.CommonInterface
{
    public interface ICalendarViewModel<T> : IObservableListViewModel<T> where T : class
    {

        public DateTime SelectedDate { get; set; }

        public IEnumerable<T> SelectedDayItems { get; set; }

        public Task DateChanged(DateTime inputDate);

        public Task ValueChanged(DateTime inputDate);
    }
}
