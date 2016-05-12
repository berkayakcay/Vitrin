using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Category1 = new List<Category>();
            this.Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }
        public string PicturePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Category> Category1 { get; set; }
        public virtual Category Category2 { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
