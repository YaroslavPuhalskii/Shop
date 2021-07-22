using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Please enter a product name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please enter a positive price")]
        public int Price { get; set; }
        [Required(ErrorMessage ="Please specify a category")]
        public string Category { get; set; }
    }
}
