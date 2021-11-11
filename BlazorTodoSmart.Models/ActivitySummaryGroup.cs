using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.Models
{
    public class ActivitySummaryGroup
    {
        public int NumItemInbox { get; set; } = 0;        
        
        public int NumItemToday { get; set; } = 0;
        
        public int NumItemUpcoming { get; set; } = 0;
    }
}
