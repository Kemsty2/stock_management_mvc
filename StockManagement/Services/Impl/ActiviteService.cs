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
    public class ActiviteService : IActiviteService
    {
        private readonly ILogger<IActiviteService> _logger;
        private readonly IStockApi _stockApi;

        public ActiviteService(ILogger<IActiviteService> logger, IStockApi stockApi)
        {
            _logger = logger;
            _stockApi = stockApi;
        }

        public async Task<IEnumerable<Achat>> GetAchats()
        {
            try
            {
                var result = await _stockApi.GetAchats();

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

        public async Task<IEnumerable<Retrait>> GetRetraits()
        {
            try
            {
                var result = await _stockApi.GetRetraits();

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

        public async Task<PaginatedResponse<Achat>> GetPaginatedAchats(PagingParams pagination)
        {
            try
            {
                var result = await _stockApi.GetPaginatedAchats(pagination);

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

        public async Task<PaginatedResponse<Retrait>> GetPaginatedRetraits(PagingParams pagination)
        {
            try
            {
                var result = await _stockApi.GetPaginatedRetraits(pagination);

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

        public async Task StoreAchat(CreateAchat achat)
        {
            try
            {
                await _stockApi.CreateAchat(achat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task StoreRetrait(CreateRetrait retrait)
        {
            try
            {
                await _stockApi.CreateRetrait(retrait);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}