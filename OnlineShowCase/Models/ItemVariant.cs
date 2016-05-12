using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShowCase.Models
{
    public partial class ItemVariant
    {
        public ItemVariant()
        {
            this.Barcodes = new List<Barcode>();
            this.Stocks = new List<Stock>();
        }

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? ItemColorId { get; set; }
        public int? ItemDimId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Barcode> Barcodes { get; set; }
        public virtual Item Item { get; set; }
        public virtual ItemColor ItemColor { get; set; }
        public virtual ItemDim ItemDim { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
