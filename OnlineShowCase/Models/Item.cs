using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShowCase.Models
{
    public partial class Item
    {
        public Item()
        {
            this.ItemVariants = new List<ItemVariant>();
            this.Prices = new List<Price>();
            this.Photos = new List<Photo>();
        }

        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? ItemDescriptionId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpdatedDate { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ItemDescription ItemDescription { get; set; }
        public virtual ICollection<ItemVariant> ItemVariants { get; set; }
        public virtual ICollection<Price> Prices { get; set; } 
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
