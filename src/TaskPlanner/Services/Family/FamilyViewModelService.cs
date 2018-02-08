using Core.Interfaces;
using Core.Model;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Interfaces;
using TaskPlanner.Models.FamilyViewModel;

namespace TaskPlanner.Services
{
    public class FamilyViewModelService : IFamilyViewModelService
    {
        private readonly IAsyncRepository<Family> _familyRepository;

        public FamilyViewModelService(IAsyncRepository<Family> familyRepository)
        {
            _familyRepository = familyRepository;
        }

        #region CreateViewModel(Family)
        public FamilyViewModel CreateViewModel(Family f)
        {
            var viewModel = new FamilyViewModel()
            {
                Id = f.Id,
                Name = f.Name
            };

            return viewModel;
        } 
        #endregion

        #region CreateViewModel()
        public FamilyViewModel CreateViewModel(FamilyDto family)
        {
            if (family != null && family.Family != null)
            {
                return new FamilyViewModel()
                {
                    Id = family.Family.Id,
                    IsActive = family.Family.IsActive,
                    Name = family.Family.Name,
                    Members = new MembersViewModel()
                    {
                        FamilyId = family.Family.Id,
                        Members = family.Members
                    }
                };
            }
            return null;
        }
        #endregion

        #region CreateVMList()
        public FamilyListViewModel CreateVMList(List<Family> families, FamilyListViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new FamilyListViewModel();
            }

            viewModel.Items = new List<FamilyListItem>();
            foreach (var f in families)
            {
                viewModel.Items.Add(new FamilyListItem()
                {
                    Id = f.Id,
                    IsActive = f.IsActive,
                    Name = f.Name
                });
            }

            return viewModel;
        } 
        #endregion
    }
}
