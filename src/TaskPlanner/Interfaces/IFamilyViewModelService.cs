using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Models.FamilyViewModel;

namespace TaskPlanner.Interfaces
{
    public interface IFamilyViewModelService
    {
        List<FamilyListItem> CreateViewModelList(List<Family> families);
        FamilyViewModel CreateViewModel(Family family);
    }
}
