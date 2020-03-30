using System;

namespace XimbleApi.Models
{
    public class GroupedOrderDetail
    {
        public DateTime DueDate { get; set; }

        public decimal LineTotal { get; set; }

        public int OrderQty { get; set; }
    }
}