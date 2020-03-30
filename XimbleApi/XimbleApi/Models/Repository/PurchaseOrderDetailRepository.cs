using System.Linq;
using XimbleApi.Models.ParametersModels;
using XimbleApi.Models.Repository.Contracts;

namespace XimbleApi.Models.Repository
{
    public class PurchaseOrderDetailRepository : DataRepository<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(AdventureWorksContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<GroupedOrderDetail> GetTrafficSumAndUnitsSoldByDays(PurchaseOrderDetailsParameters parameters)
        {
            return PagedList<GroupedOrderDetail>.ToPagedList(FindAll()
                    .GroupBy(od => od.DueDate).Where(od => od.Key >= parameters.StartTime && od.Key <= parameters.EndTime)
                    .Select(od => new GroupedOrderDetail
                    {
                        DueDate = od.Key,
                        OrderQty = od.Sum(o => o.OrderQty),
                        LineTotal = od.Sum(o => o.LineTotal),
                    })
                    .OrderBy(od => od.DueDate), parameters.PageNumber, parameters.PageSize);
        }
    }
}