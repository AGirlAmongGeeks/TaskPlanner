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

        public FamilyViewModel CreateViewModel(Family f)
        {
            var viewModel = new FamilyViewModel()
            {
                Id = f.Id,
                Name = f.Name
            };

            return viewModel;
        }

        public List<FamilyListItem> CreateViewModelList(List<Family> families)
        {
            var viewModel = new List<FamilyListItem>();
            foreach(var f in families)
            {
                viewModel.Add(new FamilyListItem()
                {
                    Id = f.Id,
                    Name = f.Name
                });
            }
           
            return viewModel;
        }
    }
}
