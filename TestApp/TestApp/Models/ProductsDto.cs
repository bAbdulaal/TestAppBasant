using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class ProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ImgURL { get; set; }

        public Guid CategoryId { get; set; }
    }
}
