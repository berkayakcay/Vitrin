using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? ItemVariantId { get; set; }
        public int? In_Qty { get; set; }
        public int? Out_Qty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ItemVariant ItemVariant { get; set; }
    }
}
