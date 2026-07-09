using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class BillItems
    {
        public int BillItemId { get; private set; }
        public int BillId { get; private set; }
        public Bills Bills { get; private set; }

        public string ItemDescription { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}
