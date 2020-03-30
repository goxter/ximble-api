using XimbleApi.Models.Repository.Contracts;

namespace XimbleApi.Models.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AdventureWorksContext _repoContext;
        private IProductRepository _product;
        private IPurchaseOrderDetailRepository _purchaseOrderDetail;

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }

        public IPurchaseOrderDetailRepository PurchaseOrderDetail
        {
            get
            {
                if (_purchaseOrderDetail == null)
                {
                    _purchaseOrderDetail = new PurchaseOrderDetailRepository(_repoContext);
                }

                return _purchaseOrderDetail;
            }
        }

        public RepositoryWrapper(AdventureWorksContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}