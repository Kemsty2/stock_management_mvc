using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Refit;
using StockManagement.Exceptions;
using StockManagement.Services.Refit;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Services.Impl
{
    public class HistoriqueService : IHistoriqueService
    {
        private readonly ILogger<IHistoriqueService> _logger;
        private readonly IStockApi _stockApi;

        public HistoriqueService(ILogger<IHistoriqueService> logger, IStockApi stockApi)
        {
            _logger = logger;
            _stockApi = stockApi;
        }

        public async Task<Historique> GetHistoriqueById(Guid id)
        {
            try
            {
                var result = await _stockApi.GetHistoriqueById(id);
                return result.Content;
            }
            catch(ApiException e){
                _logger.LogError(e.Message);                
                throw new StockApiException(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);                
                throw;
            }
        }

        public async Task<IEnumerable<Historique>> GetHistoriques()
        {
            try
            {
                var result = await _stockApi.GetHistoriques();
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

        public async Task<PaginatedResponse<Historique>> GetPaginatedHistorique(PagingParams pagination)
        {
            try
            {
                var result = await _stockApi.GetPaginatedHistoriques(pagination);
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