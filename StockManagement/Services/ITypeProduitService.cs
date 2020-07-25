using System;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockManagement.Models;

namespace StockManagement.Services
{
    public interface ITypeProduitService
    {
        Task<IEnumerable<TypeProduit>> GetTypesProduit();

        Task<PaginatedResponse<TypeProduit>> GetPaginatedTypesProduit(DataTableParams pagination);

        Task CreateTypeProduit(CreateTypeProduit typeProduit);
        Task UpdateTypeProduit(Guid id, UpdateTypeProduit typeProduit);
        Task DeleteTypeProduit(Guid id);
        Task<TypeProduit> GetTypeProduitById(Guid id);
    }
}