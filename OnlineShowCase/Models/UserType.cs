using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class UserType
    {
        public UserType()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
