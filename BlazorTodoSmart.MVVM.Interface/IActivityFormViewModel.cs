using BlazorTodoSmart.Models;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.MVVM.Interface
{
    public interface IActivityFormViewModel: IFormViewModel<ActivityItem>
    {
        public int IdActivity { get; set; }

        public string Description { get; set; }

        public int IdProject { get; set; }

        public int Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Alarm { get; set; }

        public bool IsClosed { get; set; }

        public bool IsSaveButtonEnabled { get; }
    }
}
