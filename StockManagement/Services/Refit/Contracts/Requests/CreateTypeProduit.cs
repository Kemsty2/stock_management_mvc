using System.ComponentModel.DataAnnotations;

namespace StockManagement.Services.Refit.Contracts.Requests
{
    public class CreateTypeProduit
    {
        [Required]
        [StringLength(50, ErrorMessage = "La taille maximale de ce champ est de 25 caractères")]
        public string Label { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La taille maximale de ce champ est de 80 caractères")]
        public string Description { get; set; }
    }
}