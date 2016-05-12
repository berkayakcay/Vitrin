using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class ItemDim
    {
        public ItemDim()
        {
            this.ItemVariants = new List<ItemVariant>();
        }

        public int Id { get; set; }
        public string DimCode { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
    }
}
