using Infra.Dto;
using Infra.Models;
using Infra.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infra.Services.Classes
{
    public class ProductService : IProductService
    {
        private string FilePath => Path.Combine(Environment.CurrentDirectory, "sales.json");
        public async Task<SalesSummaryDto?> GetSalesSummaryAsync()
        {
            var salesSummaryDto = new SalesSummaryDto();
       
            try
            {
                if (!File.Exists(FilePath))
                {
                    salesSummaryDto.Error = "File not found!";
                    return salesSummaryDto;
                }

                var read = await File.ReadAllTextAsync(FilePath);
                var data = JsonConvert.DeserializeObject<List<SaleEntity>>(read);
                if (data is null || data.Count == 0)
                {
                    salesSummaryDto.Error = "No sales available";
                }
                salesSummaryDto.TotalSalesAmount = data.Sum(x => x.Quantity * x.UnitPrice);
                salesSummaryDto.BestSellingProduct = data.MaxBy(x => x.Quantity).ProductName;
                salesSummaryDto.TotalOrders = data.Count;
                salesSummaryDto.AverageOrderAmount = data.Sum(x => x.Quantity * x.UnitPrice) / data.Count;

                return salesSummaryDto;
            }
            catch (Exception ex)
            {

                salesSummaryDto.Error = $"Unexpected error: {ex.Message}";
                return salesSummaryDto;
            }
         
        }
        public async Task<List<SaleEntity>?> GetSalesByName()
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            var read = await File.ReadAllTextAsync(FilePath);
            var data = JsonConvert.DeserializeObject<List<SaleEntity>>(read);
            return data.OrderBy(x => x.ProductName).ToList();
        }

        public async Task<List<SaleEntity>?> GetByQuantity()
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            var read = await File.ReadAllTextAsync(FilePath);
            var data = JsonConvert.DeserializeObject<List<SaleEntity>>(read);
            return data.OrderBy(x => x.Quantity).ToList();
        }
    }
}
