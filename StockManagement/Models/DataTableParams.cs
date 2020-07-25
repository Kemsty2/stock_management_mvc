using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models
{
    public class DataTableParams
    {
        [Required]
        public int draw { get; set; }

        [Required]
        public int start { get; set; }

        [Required]
        public int length { get; set; }

        public string search { get; set; }

        [FromQuery(Name = "order[0][column]")]
        public int orderColumn { get; set; }

        [FromQuery(Name = "order[0][dir]")]
        public string orderDir { get; set; }

        public DateTime? openDate { get; set; }

        public DateTime? closeDate { get; set; }
        
        public string sortColumn { get; set; }
    }
}