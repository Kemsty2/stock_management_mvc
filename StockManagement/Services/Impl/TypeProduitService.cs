using Microsoft.Extensions.Logging;
using Refit;
using StockManagement.Exceptions;
using StockManagement.Models;
using StockManagement.Services.Refit;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services.Impl
{
    public class TypeProduitService : ITypeProduitService
    {
        private readonly ILogger<ITypeProduitService> _logger;
        private readonly IStockApi _stockApi;

        public TypeProduitService(ILogger<ITypeProduitService> logger, IStockApi stockApi)
        {
            _logger = logger;
            _stockApi = stockApi;
        }

        public async Task<IEnumerable<TypeProduit>> GetTypesProduit()
        {
            try
            {
                var result = await _stockApi.GetTypesProduit();
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

        public async Task<PaginatedResponse<TypeProduit>> GetPaginatedTypesProduit(DataTableParams @params)
        {
            try
            {
                var pagination = new PagingParams
                {
                    PageNumber = @params.start,
                    PageSize = @params.length,
                    SearchQuery = @params.search,
                    OpenDate = @params.openDate,
                    CloseDate = @params.closeDate,
                    OrderColumn = @params.orderColumn,
                    OrderDir = @params.orderDir                    
                };

                var result = await _stockApi.GetPaginatedTypesProduit(pagination);
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

        public async Task CreateTypeProduit(CreateTypeProduit typeProduit)
        {
            try
            {
                await _stockApi.CreateTypeProduit(typeProduit);
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

        public async Task UpdateTypeProduit(Guid id, UpdateTypeProduit typeProduit)
        {
            try
            {
                await _stockApi.UpdateTypeProduit(id, typeProduit);
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

        public async Task DeleteTypeProduit(Guid id)
        {
            try
            {
                await _stockApi.DeleteTypeProduit(id);
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

        public async Task<TypeProduit> GetTypeProduitById(Guid id)
        {
            try
            {
                var result = await _stockApi.GetTypeProduitById(id);
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