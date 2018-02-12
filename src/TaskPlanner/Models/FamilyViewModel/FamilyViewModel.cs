using Core.Model;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Models.FamilyViewModel
{
    public class FamilyViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Family name")]
        public string Name { get; set; }

        //TODO! Save family creator as its owner. Or maybe admin is owner of all the families?
        public int OwnerId { get; set; }

        public MembersViewModel Members { get; set; }
    }
}
