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
        FamilyListViewModel CreateVMList(List<Family> families, FamilyListViewModel model = null);
        FamilyViewModel CreateViewModel(FamilyDto family);
    }
}
