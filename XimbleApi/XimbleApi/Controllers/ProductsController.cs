using System;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using XimbleApi.Models.Repository;
using XimbleApi.Models.ParametersModels;
using System.Web;
using System.IO;

namespace XimbleApi.Controllers
{
    //[RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        readonly IRepositoryWrapper _repository;

        public ProductsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET api/products/
        public IHttpActionResult Get([FromUri] ProductsParameters parameters)
        {
            try
            {
                var allProducts = _repository.Product.GetProducts(parameters);

                if (allProducts == null || allProducts.Count() == 0)
                {
                    return NotFound();
                }

                var metadata = new
                {
                    allProducts.TotalCount,
                    allProducts.PageSize,
                    allProducts.CurrentPage,
                    allProducts.TotalPages,
                    allProducts.HasNext,
                    allProducts.HasPrevious
                };

                HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(allProducts);

            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
