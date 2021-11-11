using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM.Interface;
using BlazorTodoSmart.Service.Interface;
using Client.MVVM.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace BlazorTodoSmart.MVVM
{
    public class ActivityListViewModel : BaseGridViewModel<ActivityItem>, IActivityListViewModel
    {
        private IActivityItemService itemService;
        private int iDProject = 0;
        public ActivityListViewModel(IActivityItemService bService) : base(bService)
        {
            itemService = bService;
        }

        public int IDProject { get => iDProject; set { if (value != iDProject) { iDProject = value; OnPropertyChanged("IDProject"); } } }

        public int IDActivitySelected
        {
            get
            {
                return CurrentItem != null ? CurrentItem.IdActivity : 0;
            }
        }

        public DateTime? FilterDate { get; set; }
        public int FilterMode { get; set; } = 0;

        public override async Task ReadItems(GridReadEventArgs args)
        {
            if (filterDescriptors == null)
                filterDescriptors = new List<IFilterDescriptor> { new FilterDescriptor(nameof(ActivityItem.IsClosed), FilterOperator.IsEqualTo, false) };

            if (FilterDate.HasValue && !filterDescriptors.Any(x => (x as FilterDescriptor).Member.Equals(nameof(ActivityItem.DueDate)))) 
            {
                DateTime startofDay = FilterDate.Value.Date;
                DateTime endOfDay = startofDay.AddDays(1).AddTicks(-1);

               

                FilterDescriptor fdStart = new FilterDescriptor(nameof(ActivityItem.DueDate), FilterOperator.IsGreaterThanOrEqualTo, startofDay);

                if (FilterMode == 1)
                {
                    fdStart = new FilterDescriptor(nameof(ActivityItem.DueDate), FilterOperator.IsGreaterThan, startofDay);
                }

                filterDescriptors.Add(fdStart);

                if (FilterMode==0)
                {
                    FilterDescriptor fdEnd = new FilterDescriptor(nameof(ActivityItem.DueDate), FilterOperator.IsLessThanOrEqualTo, endOfDay);

                    filterDescriptors.Add(fdEnd);
                }

                
            }

            await base.ReadItems(args);
        }
        public ActivityItem GetActivityByID(int idActivity)
        {
            var coll = ((IEnumerable<Object>)GridSource).Cast<ActivityItem>();

            ActivityItem item = coll.FirstOrDefault(f => f.IdActivity == idActivity);

            return item;
        }

        public async Task UndoCancelActity(int idactivity)
        {
           
            if (idactivity>0 && GridSource!=null)
            {

                var item = GetActivityByID(idactivity);

                item.IsClosed = false;

                await RefreshData();
            }
        }

        protected override async Task<IEnumerable<ActivityItem>> getAllItems()
        {
            var itemList=await base.getAllItems();

            var outList = (from a in itemList orderby a.DueDateValue select a);

            return outList;

        }
    }
}
