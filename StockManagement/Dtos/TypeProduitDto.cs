using System.ComponentModel.DataAnnotations;

namespace StockManagement.Dtos
{
    public class TypeProduitDto
    {
        [Required]
        [StringLength(25, ErrorMessage = "La taille maximale de ce champ est de 25 caractères")]
        public string Label { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "La taille maximale de ce champ est de 80 caractères")]
        public string Description { get; set; }
    }
}