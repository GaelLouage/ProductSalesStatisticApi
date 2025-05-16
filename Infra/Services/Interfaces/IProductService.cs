using Infra.Dto;
using Infra.Models;

namespace Infra.Services.Interfaces
{
    public interface IProductService
    {
        Task<SalesSummaryDto> GetSalesSummaryAsync();
        Task<List<SaleEntity>?> GetByQuantity();
        Task<List<SaleEntity>?> GetSalesByName();
    }
}