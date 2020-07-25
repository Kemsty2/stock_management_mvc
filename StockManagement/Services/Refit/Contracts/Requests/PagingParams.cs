using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SearchQuery { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CloseDate { get; set; }
    }
}