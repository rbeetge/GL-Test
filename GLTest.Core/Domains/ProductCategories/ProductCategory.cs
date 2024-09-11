using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLTest.Core.Domains.ProductCategories
{
    public class ProductCategory
    {
        public Guid ProductCategoryId { get; private set; }
        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }

        protected ProductCategory() { }

        protected ProductCategory Create(Guid productId, Guid categoryId)
        {
            return new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };
        }
    }
}
