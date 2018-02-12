using Core.Data;
using Core.Model;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFamilyRepository : IRepository<Family>, IAsyncRepository<Family>
    {
        Task<List<Family>> GetAllActive();
        Task<FamilyDto> GetByIdWithMembersAsync(int id);
        Task DesactivateAsync(int familyId);
    }
}
