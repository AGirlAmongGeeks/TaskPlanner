using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFamilyService
    {
        Task<Family> CreateAsync(Family item);
        Task DeleteFamilyAsync(int familyId);
        Task<List<Family>> GetAllActiveAsync();
        Task<List<Family>> GetAllAsync();
        Task<Family> GetByIdAsync(int id);
        Task UpdateAsync(Family family);
    }
}
