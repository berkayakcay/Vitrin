using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShowCase.Models
{
    public partial class ItemColor
    {
        public ItemColor()
        {
            this.ItemVariants = new List<ItemVariant>();
        }

        public int Id { get; set; }
        public string ColorCode { get; set; }
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpdatedDate { get; set; }

        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
    }
}
