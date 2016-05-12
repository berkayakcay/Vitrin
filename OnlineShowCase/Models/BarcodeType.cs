using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class BarcodeType
    {
        public BarcodeType()
        {
            this.Barcodes = new List<Barcode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Barcode> Barcodes { get; set; }
    }
}
