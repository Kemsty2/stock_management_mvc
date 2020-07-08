using System.Collections.Generic;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class PaginatedResponse<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
    }
}