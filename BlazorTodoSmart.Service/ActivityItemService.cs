using BlazorTodoSmart.Models;
using BlazorTodoSmart.Service.Interface;
using Client.CommonService;
using Client.CommonService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.Service
{
    public class ActivityItemService : BaseService<ActivityItem>, IActivityItemService
    {
        public ActivityItemService(IRepository<ActivityItem> repo) : base(repo)
        {

        }
    }
}
