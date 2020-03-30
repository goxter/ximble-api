using System;

namespace XimbleApi.Models.ParametersModels
{
    public class ProductsParameters : QueryStringParameters
    {
        public string Name { get; set; } = null;

        public DateTime SellStartDate { get; set; } = default(DateTime);

        public string Description { get; set; } = null;
    }
}