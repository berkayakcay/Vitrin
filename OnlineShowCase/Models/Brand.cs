using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Brand
    {
        public Brand()
        {
            this.Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
