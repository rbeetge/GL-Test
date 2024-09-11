using GLTest.Core.Common;

namespace GLTest.Core.Domains.ProductCategories
{
    public interface IProductCategoryFactory
    {
        public ResultModel<ProductCategory> CreateInstance(Guid productId, Guid categoryId);
    }
}
