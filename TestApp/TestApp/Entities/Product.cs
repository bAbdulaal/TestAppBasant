using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Price { get; set; }

        [MaxLength(10)]
        public string Quantity { get; set; }

        [MaxLength(1500)]
        public string ImgURL { get; set; }

        public Guid CategoryId { get; set; }

    }
}