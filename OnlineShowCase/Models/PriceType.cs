using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class PriceType
    {
        public PriceType()
        {
            this.Prices = new List<Price>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
