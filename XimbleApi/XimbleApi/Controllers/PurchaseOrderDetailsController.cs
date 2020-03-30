using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Http;
using XimbleApi.Models.ParametersModels;
using XimbleApi.Models.Repository;

namespace XimbleApi.Controllers
{
    public class PurchaseOrderDetailsController : ApiController
    {
        readonly IRepositoryWrapper _repository;

        public PurchaseOrderDetailsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/PurchaseOrderDetails?startTime=2011-05-05&endTime=2018-05-05
        // GET: api/PurchaseOrderDetails?startTime=2011-05-05&endTime=2018-05-05&pagenumber=1&pagesize=1
        public IHttpActionResult Get([FromUri] PurchaseOrderDetailsParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var results = _repository.PurchaseOrderDetail.GetTrafficSumAndUnitsSoldByDays(parameters);

                var metadata = new
                {
                    results.TotalCount,
                    results.PageSize,
                    results.CurrentPage,
                    results.TotalPages,
                    results.HasNext,
                    results.HasPrevious
                };                

                HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(results);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}