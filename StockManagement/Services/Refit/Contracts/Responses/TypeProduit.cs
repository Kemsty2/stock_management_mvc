using System;

namespace StockManagement.Services.Refit.Contracts.Responses
{
    public class TypeProduit
    {
        public Guid Id {get;set;}
        public string Label {get;set;}
        public string Description {get;set;}
        public bool IsDeleted {get;set;}
        public string CreatedBy {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public string UpdatedBy{get;set;}
    }
}