using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class CustomerDayViewModel
    {
        public List<Customer> Customers { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
