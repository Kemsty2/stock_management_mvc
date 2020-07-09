using Microsoft.Extensions.Logging;
using Refit;
using StockManagement.Exceptions;
using StockManagement.Services.Refit;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services.Impl
{
    public class StockService : IStockService
    {
        private readonly ILogger<IStockService> _logger;
        private readonly IStockApi _stockApi;

        public StockService(ILogger<IStockService> logger, IStockApi stockApi)
        {
            _logger = logger;
            _stockApi = stockApi;
        }

        public async Task<IEnumerable<Produit>> GetProduits()
        {
            try
            {
                var result = await _stockApi.GetProduits();
                return result.Content;
            }
            catch (ApiException e)
            {
                throw new StockApiException(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<PaginatedResponse<Produit>> GetPaginatedProduit(PagingParams pagination)
        {
            try
            {
                var result = await _stockApi.GetPaginatedProduits(pagination);
                return result.Content;
            }
            catch (ApiException e)
            {
                throw new StockApiException(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Produit> GetProduitById(Guid id)
        {
             try
            {
                var result = await _stockApi.GetProduitById(id);
                return result.Content;
            }
            catch (ApiException e)
            {
                throw new StockApiException(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}