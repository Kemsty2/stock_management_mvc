using System;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class UpdateTypeProduit
    {
        public Guid Id {get;set;}
        public string Label {get;set;}
    }
}