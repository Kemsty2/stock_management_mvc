using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Produit>> GetProduits();

        Task<PaginatedResponse<Produit>> GetPaginatedProduit(PagingParams pagination);
    }
}