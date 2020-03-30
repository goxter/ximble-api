using System;
using System.Web.ModelBinding;

namespace XimbleApi.Models.ParametersModels
{
    public class PurchaseOrderDetailsParameters : QueryStringParameters
	{
		[BindRequired]
		public DateTime StartTime { get; set; }
		[BindRequired]
		public DateTime EndTime { get; set; }
	}
}