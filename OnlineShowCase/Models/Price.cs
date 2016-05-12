using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Price
    {
        public int Id { get; set; }
        public int? PriceTypeId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemPrice { get; set; }
        public int? VatRate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual Item Item { get; set; }
        public virtual PriceType PriceType { get; set; }
    }
}
