using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Models.FamilyViewModel
{
    public class MembersViewModel
    {
        public int FamilyId { get; set; }
        public List<FamilyMemberDto> Members { get; set; }
    }
}
