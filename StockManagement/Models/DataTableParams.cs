using System;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Models
{
    public class DataTableParams
    {
        [FromForm(Name = "draw")]
        public int draw { get; set; }

        [FromForm(Name = "start")]
        public int start { get; set; }

        [FromForm(Name = "length")]
        public int length { get; set; }

        [FromForm(Name = "search[value]")]
        public string search { get; set; }

        [FromForm(Name = "order[0][column]")]
        public int orderColumn { get; set; }

        [FromForm(Name = "order[0][dir]")]
        public string orderDir { get; set; }

        public DateTime? openDate {get;set;}
        public DateTime? closeDate {get;set;}        
    }
}