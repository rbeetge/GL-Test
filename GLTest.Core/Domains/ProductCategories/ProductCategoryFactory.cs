using GLTest.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLTest.Core.Domains.ProductCategories
{
    internal class ProductCategoryFactory : ProductCategory, IProductCategoryFactory
    {
        public ResultModel<ProductCategory> CreateInstance(Guid productId, Guid categoryId)
        {
            if (productId == default || categoryId == default)
                return new ResultModel<ProductCategory>(false, "Valid ProductId/CategoryId required");

            var result = Create(productId, categoryId);
            return new ResultModel<ProductCategory>(result);
        }
    }
}
