using GLTest.Core.Common;
using GLTest.Core.Domains.ProductCategories;
using GLTest.Core.Repositories.Categories;
using GLTest.Core.Repositories.ProductCategories;
using GLTest.Core.Repositories.Products;

namespace GLTest.Core.Commands.Products
{
    public class SetProductCategoryCommand : ISetProductCategoryCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductCategoryFactory _productCategoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public SetProductCategoryCommand(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductCategoryRepository productCategoryRepository,
            IProductCategoryFactory productCategoryFactory,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryFactory = productCategoryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<bool>> ExecuteAsync(Guid productId, Guid categoryId)
        {
            var product = await _productRepository.FirstOrDefaultAsync(a => a.ProductId == productId);
            if (product == null)
                return new CommandResult<bool>("Set_Product_Category_Product_NotFound", "Product not found. ");

            var category = await _categoryRepository.FirstOrDefaultAsync(a => a.CategoryId == categoryId);
            if (category == null)
                return new CommandResult<bool>("Set_Product_Category_Category_NotFound", "Category not found. ");

            var productCategories = await _productCategoryRepository.FirstOrDefaultAsync(a => a.ProductId == productId && a.CategoryId == categoryId);
            if (productCategories != null)
                return new CommandResult<bool>("Set_Product_Category_Category_Already_Added", "Product already added to Category. ");

            var creationResult = _productCategoryFactory.CreateInstance(productId, categoryId);
            _productCategoryRepository.Add(creationResult.Result);
            await _unitOfWork.CommitAsync();

            return new CommandResult<bool>(true);
        }
    }
}
