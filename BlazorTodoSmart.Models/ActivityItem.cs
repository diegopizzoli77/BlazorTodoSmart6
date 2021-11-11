using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.Models
{
    public class ActivityItem
    {
        [Key]
        public int IdActivity { get; set; }

        public string Description { get; set; }

        public int IdProject { get; set; }

        public int Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Alarm { get; set; }

        public bool IsClosed { get; set; } = false;

        public DateTime DueDateValue
        {
            get => DueDate ?? DateTime.Now;
        }
        public string DueDateString
        {
            get
            {
                if (DueDate.HasValue)
                    return DueDate.Value.ToShortDateString();
                else
                    return "none";
            }
        }

    }
}
