using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Data;
using System.Threading.Tasks;
using TaskPlanner.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Model;
using Data.Models;

namespace Data.Repositories
{
    public class FamilyRepository : EFRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DesactivateAsync(int familyId)
        {
            var family = await _dbContext.Families
                   .Where(c => c.Id == familyId)
                   .FirstOrDefaultAsync();
            if(family != null)
            {
                family.IsActive = false;

                _dbContext.Entry(family).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }


        public Task<List<Family>> GetAllActive()
        {
            return _dbContext.Families
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }

        public async Task<FamilyDto> GetByIdWithMembersAsync(int familyId)
        {
            var result = new FamilyDto();
            result.Family = await _dbContext.Families
                   .Where(c => c.Id == familyId)
                   .FirstOrDefaultAsync();

            if(result.Family != null)
            {
                result.Members = await _dbContext.Users
                    .Where(c => c.Family.Id == familyId)
                    .Select(c => new FamilyMemberDto() { Email = c.Email})
                    .ToListAsync();
            }

            return result;
        }

        public Task<List<ApplicationUser>> GetFamilyMembers(int familyId)
        {
            return _dbContext.Users
                .Where(c => c.Family.Id == familyId)
                .ToListAsync();
        }
       
    }
}
