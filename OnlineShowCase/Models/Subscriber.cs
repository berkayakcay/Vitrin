using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class Subscriber
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendSms { get; set; }
        public bool? SendNotification { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual User User { get; set; }
    }
}
