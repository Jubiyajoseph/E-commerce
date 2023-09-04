using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.ProductsModel
{
    public class Product
    {
        public int Id { get;  }
        public string Name { get; private set; }= string.Empty;
        public decimal Weight { get; private set; }
        public int  Stock { get; private set; }
        public int BrandId { get; private set; }
        public Brand? Brand { get; set; }
        public int CategoryId { get; private set; }
        public Category? Category { get; set; }
        public decimal UnitPrice { get; private set; }

        public Product(string name, decimal weight, int stock, int brandId, int categoryId, decimal unitPrice)
        {
            Name = name;
            Weight = weight;
            Stock = stock;
            BrandId = brandId;
            CategoryId = categoryId;
            UnitPrice = unitPrice;
        }
    }
}
