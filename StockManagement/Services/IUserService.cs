using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<PaginatedResponse<User>> GetPaginatedUsers(PagingParams pagination);

        Task CreateUser(CreateUser user);

        Task UpdateUser(Guid id, UpdateUser user);

        Task ToggleStatusUser(Guid id);

        Task<User> GetUserById(Guid id);
    }
}