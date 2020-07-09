using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public interface IActiviteService
    {
        Task<IEnumerable<Achat>> GetAchats();

        Task<IEnumerable<Retrait>> GetRetraits();

        Task<PaginatedResponse<Achat>> GetPaginatedAchats(PagingParams pagination);

        Task<PaginatedResponse<Retrait>> GetPaginatedRetraits(PagingParams pagination);

        Task StoreAchat(CreateAchat achat);

        Task StoreRetrait(CreateRetrait retrait);

        Task<Achat> GetAchatById(Guid id);
        Task<Retrait> GetRetraitById(Guid id);
    }
}