using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM.Interface;
using BlazorTodoSmart.Service.Interface;
using Client.CommonService.Interface;
using Client.MVVM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM
{
    public class ListActivityPageViewModel : BaseViewModel<ActivityItem>, IListActivityPageViewModel
    {
        private int iDActivitySelected;
        private bool activityChecked = false;

        public IActivityFormViewModel UpdateActivityVM { get; set; }
        public IActivityListViewModel ActivityListVM { get; set; }
        public int IDActivitySelected { get => iDActivitySelected; 
            set
            {
                if (value != iDActivitySelected)
                {
                    iDActivitySelected = value;
                    OnPropertyChanged("IDActivitySelected");
                }
            }
        }

        public bool ActivityChecked { get => activityChecked;
            set
            {
                if (value != activityChecked)
                {
                    activityChecked = value;
                    OnPropertyChanged("ActivityChecked");
                }
            }
        }

        public ListActivityPageViewModel(IActivityMainService bService) : base(bService)
        {

        }

        public async Task OnActivityDone()
        {            
            ActivityChecked = false;
            var itemToSave = ActivityListVM.GetActivityByID(IDActivitySelected);
            await baseService.Update(itemToSave);
            await ActivityListVM.RefreshData();
        }

        public async Task OnActivitySelected(int idactivity)
        {
            IDActivitySelected = idactivity;
            await UpdateActivityVM.InitForm(idactivity);
        }

        public async Task OnActivityUpdated()
        {
            await ActivityListVM.RefreshData();
        }

        public async Task OnActivityChecked(int idactivity)
        {
            iDActivitySelected = idactivity;

          await Task.Run(() => { ActivityChecked = true; });
        }

        public async Task OnActivityUndo()
        {
            ActivityChecked = false;
            await Task.Run(() => { ActivityListVM.UndoCancelActity(iDActivitySelected); });
        }
    }
}
