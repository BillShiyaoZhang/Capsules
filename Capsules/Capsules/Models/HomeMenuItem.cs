using System;
using System.Collections.Generic;
using System.Text;

namespace Capsules.Models
{
    public enum MenuItemType
    {
        Browse,
        Drafts,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
