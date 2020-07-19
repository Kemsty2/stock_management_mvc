using System;
using Microsoft.AspNetCore.Http;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class CreateAchat
    {
        public string Label { get; set; }
        public int Quantite { get; set; }
        public Guid TypeProduitId { get; set; }
        public double Montant {get;set;}
        public DateTime DateAchat {get;set;}
        public IFormFile Justificatif {get;set;}
        public string Description {get;set;}
    }
}