using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ImgURL { get; set; }
        [Required(ErrorMessage = "You should fill out a name.")]
        public Guid CategoryId { get; set; }
    }
}
