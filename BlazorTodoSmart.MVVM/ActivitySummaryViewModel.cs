using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM.Interface;
using BlazorTodoSmart.Service.Interface;
using Client.MVVM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM
{
    public class ActivitySummaryViewModel : BaseObservableListViewModel<ActivitySummaryGroup>, IActivitySummaryViewModel
    {
        private IActivitySummaryService myservice = null;
        private int numItemInbox = 0;
        private int numItemToday = 0;
        private int numItemUpcoming = 0;

        public ActivitySummaryViewModel(IActivitySummaryService service) : base(service)
        {
            myservice = service;
        }


        public int NumItemInbox { get => numItemInbox;
            set {
                if (value != numItemInbox)
                {
                    numItemInbox = value;
                    OnPropertyChanged("NumItemInbox");
                }
            }
        }
        public int NumItemToday { get => numItemToday; set
            {
                if (value != numItemToday)
                {
                    numItemToday = value;
                    OnPropertyChanged("NumItemToday");
                }
            }
        }
        public int NumItemUpcoming { get => numItemUpcoming; set
            {
                if (value != numItemUpcoming)
                {
                    numItemUpcoming = value;
                    OnPropertyChanged("NumItemUpcoming");
                }
            }
        }


        public override async Task LoadAllItems()
        {
            await base.LoadAllItems();

            ActivitySummaryGroup summaryGroup = this.ListViewSource.FirstOrDefault();

            if (summaryGroup!=null)
            {
                NumItemInbox = summaryGroup.NumItemInbox;
                NumItemToday = summaryGroup.NumItemToday;
                NumItemUpcoming = summaryGroup.NumItemUpcoming;
            }
            else
            {
                NumItemInbox = 0;
                NumItemToday = 0;
                NumItemUpcoming = 0;
            }

        }

        
    }
}
