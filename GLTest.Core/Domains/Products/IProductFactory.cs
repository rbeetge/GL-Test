using GLTest.Core.Common;

namespace GLTest.Core.Domains.Products
{
    public interface IProductFactory
    {
        public ResultModel<Product> CreateInstance(string name);
    }
}
