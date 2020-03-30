using System.Linq;
using XimbleApi.Models.ParametersModels;
using XimbleApi.Models.Repository;
using XimbleApi.Models.Repository.Contracts;

namespace XimbleApi.Models
{
    public class ProductRepository : DataRepository<Product>, IProductRepository
    { 

        public ProductRepository(AdventureWorksContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Product> GetProducts(ProductsParameters parameters)
        {
            IQueryable<Product> allProducts = null;

            if (!string.IsNullOrEmpty(parameters.Description))
            {
                allProducts = FindAllByDescription(parameters.Description);
            }
            else
            {
                allProducts = FindAll();
            }

            if (parameters.SellStartDate != default)
            {
                allProducts = allProducts.Where(p => p.SellStartDate.Equals(parameters.SellStartDate));
            }

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                allProducts = allProducts.Where(p => p.Name == parameters.Name);
            }                       

            return PagedList<Product>.ToPagedList(allProducts.OrderBy(p => p.Name),
                parameters.PageNumber,
                parameters.PageSize);
        }

        private IQueryable<Product> FindAllByDescription(string description)
        {
            return from products in RepositoryContext.Products
                      join productDescriptions in RepositoryContext.ProductDescriptions on products.rowguid equals productDescriptions.rowguid
                      where productDescriptions.Description.Contains(description)
                      select products;
        }
    }
}