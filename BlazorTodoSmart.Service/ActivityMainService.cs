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
    public class ActivityMainService : BaseService<ActivityItem>, IActivityMainService
    {
        public ActivityMainService(IRepository<ActivityItem> repo) : base(repo)
        {

        }
    }
}
