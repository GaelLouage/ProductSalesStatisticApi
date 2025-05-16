using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dto
{
    public class SalesSummaryDto
    {
        public decimal TotalSalesAmount { get; set; }
        public int TotalOrders { get; set; }
        public string BestSellingProduct { get; set; }
        public decimal AverageOrderAmount { get; set; }
        public string? Error { get; set; }
    }

}
