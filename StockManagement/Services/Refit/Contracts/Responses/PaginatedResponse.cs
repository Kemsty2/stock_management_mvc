using System.Collections.Generic;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class PaginatedResponse<T> where T : class
    {
        public List<T> Data { get; set; }
        public PagingHeader Paging {get;set;}
    }

    public class PagingHeader {
        public int TotalItems {get;set;}
        public int PageNumber {get;set;}
        public int PageSize {get;set;}
        public bool HasPreviousPage {get;set;}
        public bool HasNextPage {get;set;}
    }

}