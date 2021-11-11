using BlazorTodoSmart.Models;
using BlazorTodoSmart.Service.Interface;
using Client.CommonService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.Service
{
    public class ActivitySummaryService : IActivitySummaryService
    {
        private IRepository<ActivityItem> dbcontext;
        public ActivitySummaryService(IRepository<ActivityItem> indexDBContext)
        {
            dbcontext = indexDBContext;
        }

        public Task<bool> FinalDelete<TKey>(TKey id_dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActivitySummaryGroup>> GetSummaries()
        {
            throw new NotImplementedException();
        }

        public Task<ActivitySummaryGroup> Insert(ActivitySummaryGroup item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogicalDelete<TKey>(TKey id_dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActivitySummaryGroup>> SelectAll()
        {
            var res =await dbcontext.GetAll();

            ActivitySummaryGroup summary = new ActivitySummaryGroup { NumItemInbox = 0, NumItemToday = 0, NumItemUpcoming = 0 };
            
            if (res!=null)
            {
                summary.NumItemInbox = res.Where(x => x.IsClosed == false).Count();
                summary.NumItemToday = res.Where(x => x.IsClosed == false && x.DueDate.HasValue 
                            && x.DueDate.Value.Date == DateTime.Now.Date
                            ).Count();
                summary.NumItemUpcoming = res.Where(x => x.IsClosed == false && x.DueDate.HasValue
                            && x.DueDate.Value.Date > DateTime.Now.Date).Count();
            } 

            IEnumerable<ActivitySummaryGroup> ret = new List<ActivitySummaryGroup> { summary };

            return ret;
        }

        public Task<ActivitySummaryGroup> SelectById<TKey>(TKey id_dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ActivitySummaryGroup item)
        {
            throw new NotImplementedException();
        }
    }
}
