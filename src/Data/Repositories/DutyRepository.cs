using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Data;
using System.Threading.Tasks;
using TaskPlanner.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DutyRepository : EFRepository<Duty>, IDutyRepository
    {
        public DutyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Duty>> GetByFamilyIdAsync(int familyId)
        {
            throw new NotImplementedException();
            //await _dbContext.Duties.Where(c => c.F)
        }
    }
}
