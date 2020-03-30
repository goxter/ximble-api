using XimbleApi.Models.ParametersModels;

namespace XimbleApi.Models.Repository.Contracts
{
    public interface IProductRepository : IDataRepository<Product>
    {
        PagedList<Product> GetProducts(ProductsParameters parameters);
    }
}
