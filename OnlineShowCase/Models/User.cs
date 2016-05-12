using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class User
    {
        public User()
        {
            this.Subscribers = new List<Subscriber>();
        }

        public int Id { get; set; }
        public int? UserTypeId { get; set; }
        public string FirstLast { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
