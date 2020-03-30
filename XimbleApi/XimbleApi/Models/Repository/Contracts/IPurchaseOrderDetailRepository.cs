using XimbleApi.Models.ParametersModels;

namespace XimbleApi.Models.Repository.Contracts
{
    public interface IPurchaseOrderDetailRepository : IDataRepository<PurchaseOrderDetail>
    {
        PagedList<GroupedOrderDetail> GetTrafficSumAndUnitsSoldByDays(PurchaseOrderDetailsParameters parameters);
    }
}
