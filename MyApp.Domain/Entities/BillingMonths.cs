using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class BillingMonths
    {
        public int BillingMonthId { get; set; }
        public string MonthName { get; set; }
        public string Year {  get; set; }
        public DateOnly DueDate { get; set; }

        public ICollection<MeterReadings> MeterReadings = new List<MeterReadings>();
        protected BillingMonths() { }

        public BillingMonths(string monthName, string year, DateOnly dueDate)
        {
            MonthName = monthName;
            Year = year;
            DueDate = dueDate;
        }
    }
}
