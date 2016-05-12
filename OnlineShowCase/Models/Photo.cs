using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string PhotoPath_S { get; set; }
        public string PhotoPath_M { get; set; }
        public string PhotoPath_B { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual Item Item { get; set; }
    }
}
