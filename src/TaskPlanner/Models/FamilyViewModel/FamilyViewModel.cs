using Core.Model;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Models.FamilyViewModel
{
    public class FamilyViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        //TODO! Save family creator as its owner. Or maybe admin is owner of all the families?
        public int OwnerId { get; set; }

        public List<FamilyMemberDto> Members { get; set; }
    }
}
