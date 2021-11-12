using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoSmart.Models
{
    public class PriorityItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string IconName { get; set; }    

        public string IconClass { get; set; }
    }
}
