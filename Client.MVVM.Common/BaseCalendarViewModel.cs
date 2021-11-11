using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.Common
{
    public abstract class BaseCalendarViewModel<T> : BaseObservableListViewModel<T>, ICalendarViewModel<T> where T:class
    {
        protected IEnumerable<T> selectedDayItems = null;

        public BaseCalendarViewModel(IBaseService<T> bService) : base(bService)
        {

        }

        public IEnumerable<T> SelectedDayItems { get => selectedDayItems; 
            set
            {
                if (value != selectedDayItems)
                {
                    selectedDayItems = value;
                    OnPropertyChanged("SelectedDayItems");
                }
            }
        }

        public DateTime SelectedDate { get; set; }

        public abstract Task DateChanged(DateTime inputDate);
        public abstract Task ValueChanged(DateTime inputDate);
    }
}
