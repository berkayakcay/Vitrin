using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Barcode
    {
        public int Id { get; set; }
        public int? ItemVariantId { get; set; }
        public int? BarcodeTypeId { get; set; }
        public string ItemBarcode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual BarcodeType BarcodeType { get; set; }
        public virtual ItemVariant ItemVariant { get; set; }
    }
}
