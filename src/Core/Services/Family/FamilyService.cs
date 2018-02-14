using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyService(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public Task<Family> CreateAsync(Family item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Object cannot be null");
            }
            if(item.Id > 0)
            {
                throw new ArgumentException("Created Object Id should be 0. Do you want to update object?");
            }
            return _familyRepository.AddAsync(item);
        }

        public async Task DeleteFamilyAsync(int familyId)
        {
            var family = await _familyRepository.GetByIdAsync(familyId);

            await _familyRepository.DeleteAsync(family);
        }

        public async Task<List<Family>> GetAllAsync()
        {
            return await _familyRepository.ListAllAsync();
        }

        public async Task<List<Family>> GetAllActiveAsync()
        {
            return await _familyRepository.GetAllActive();
        }

        public async Task<Family> GetByIdAsync(int id)
        {
            return await _familyRepository.GetByIdAsync(id);
        }

        public async Task<FamilyDto> GetByIdWithMembersAsync(int id)
        {
            return await _familyRepository.GetByIdWithMembersAsync(id);
        }

        public Task UpdateAsync(Family item)
        {
            return _familyRepository.UpdateAsync(item);
        }

        public async Task DesactivateAsync(int familyId)
        {
            //TODO Check admin/owner authentication.
            await _familyRepository.DesactivateAsync(familyId);
        }
    }
}
