using BlazorTodoSmart.Models;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM.Interface
{
    public interface IListActivityPageViewModel : IViewModelBase<ActivityItem>
    {
        public IActivityFormViewModel UpdateActivityVM { get; set; }

        public IActivityListViewModel ActivityListVM { get; set; }

        public bool ActivityChecked { get; set; }

        public int IDActivitySelected { get; set; }

        public Task OnActivitySelected(int idactivity);

        public Task OnActivityChecked(int idactivity);

        public Task OnActivityUpdated();

        public Task OnActivityDone();

        public Task OnActivityUndo();
    }
}
