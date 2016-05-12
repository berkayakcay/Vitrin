using System;
using System.Collections.Generic;

namespace OnlineShowCase.Models
{
    public partial class MainMenu
    {
        public MainMenu()
        {
            this.MainMenu1 = new List<MainMenu>();
        }
        public int Id { get; set; }
        public int? SubMenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool? ForAdmin { get; set; }
        public bool? ForMod { get; set; }
        public bool? ForUser { get; set; }
        public virtual ICollection<MainMenu> MainMenu1 { get; set; }
        public virtual MainMenu MainMenu2 { get; set; }
    }
}
