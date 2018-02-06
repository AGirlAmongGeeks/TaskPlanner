using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Models.FamilyViewModel
{
    public class FamilyListViewModel
    {
        public bool ShowAll { get; set; }
        public List<FamilyListItem> Items { get; set; }
    }
}
