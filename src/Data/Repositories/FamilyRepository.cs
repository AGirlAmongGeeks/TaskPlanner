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

namespace Data.Repositories
{
    public class FamilyRepository : EFRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Family>> GetAllActive()
        {
            return _dbContext.Families
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }
    }
}
