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
    public class ActivityCalendarViewModel : BaseCalendarViewModel<ActivityItem>, IActivityCalendarViewModel
    {

        #region Public Properties

        public List<DateTime> CarouselData { get ; set ; }

        #endregion

        #region Ctor

        public ActivityCalendarViewModel(IActivityItemService baseService) : base(baseService)
        {
            CarouselData = initCarouselData();
            SelectedDate = DateTime.Now;
        }

        #endregion

        #region Overrides

        public override async Task RefreshData()
        {
            await LoadAllItems();
            await filterData(SelectedDate);
        }

        #endregion

        #region Implements

        public async Task PageChangedHandler(int newPage)
        {
            await this.DateChanged(CarouselData[newPage - 1]);
        }

        public override async Task DateChanged(DateTime inputDate)
        {
            await filterData(inputDate);            
        }

        public override async Task ValueChanged(DateTime inputDate)
        {
            await filterData(inputDate);            
        }

        protected override async Task<IEnumerable<ActivityItem>> getAllItems()
        {
            IEnumerable<ActivityItem> res = await base.getAllItems();
            IEnumerable<ActivityItem> ret = null;
            if (res != null)
                ret = (from elem in res where elem.IsClosed == false select elem);

            return ret;
        }

        public bool HasDateEvents(DateTime inputDate)
        {
            if (ListViewSource == null)
                return false;

            return ListViewSource.Any(x => normalizeDate(x.DueDate).Date.Equals(inputDate.Date));
        }

        #endregion

        #region Private Methods

        private DateTime getNextDate(int month)
        {
            return DateTime.Now.AddMonths(month);
        }

        private List<DateTime> initCarouselData()
        {            
            return new List<DateTime> { DateTime.Now, 
                new DateTime(getNextDate(1).Year, getNextDate(1).Month, 1),
                new DateTime(getNextDate(2).Year, getNextDate(2).Month, 1)
            };
        }

        private DateTime normalizeDate(DateTime? actualDate)
        {
            return actualDate.HasValue ? actualDate.Value : DateTime.Now;

        }

        private async Task filterData(DateTime inputDate)
        {
            SelectedDate = inputDate;

            if (ListViewSource != null)
            {
                await Task.Run(() => SelectedDayItems = (from a in ListViewSource where normalizeDate(a.DueDate).Date.Equals(inputDate.Date) select a).ToList());
            }
        }

       



        #endregion






    }
}
