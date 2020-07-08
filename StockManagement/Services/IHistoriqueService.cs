using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Services
{
    public interface IHistoriqueService
    {
        Task<IEnumerable<Historique>> GetHistoriques();
        Task<PaginatedResponse<Historique>> GetPaginatedHistorique(PagingParams pagination);
    }
}