using XimbleApi.Models.Repository.Contracts;

namespace XimbleApi.Models.Repository
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IPurchaseOrderDetailRepository PurchaseOrderDetail { get; }
        void Save();
    }
}
