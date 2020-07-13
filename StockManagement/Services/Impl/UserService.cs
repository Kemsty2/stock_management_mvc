using Microsoft.Extensions.Logging;
using StockManagement.Services.Refit;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using StockManagement.Exceptions;

namespace StockManagement.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly ILogger<IUserService> _logger;
        private readonly IStockApi _stockApi;

        public UserService(ILogger<IUserService> logger, IStockApi stockApi)
        {
            _logger = logger;
            _stockApi = stockApi;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var result = await _stockApi.GetUsers();
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

        public async Task<PaginatedResponse<User>> GetPaginatedUsers(PagingParams pagination)
        {
            try
            {
                var result = await _stockApi.GetPaginatedUsers(pagination);
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

        public async Task CreateUser(CreateUser user)
        {
            try
            {
                await _stockApi.CreateUser(user);
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

        public async Task UpdateUser(Guid id, UpdateUser user)
        {
            try
            {
                await _stockApi.UpdateUser(id, user);
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

        public async Task ToggleStatusUser(Guid id)
        {
            try
            {
                await _stockApi.ToggleStatusUser(id);
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

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var result = await _stockApi.GetUserById(id);
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

        public async Task<LoginResponse> AuthenticateUser(LoginUser payload)
        {
            try
            {
                var result = await _stockApi.LoginUser(payload);   
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