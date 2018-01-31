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

        public Task<List<Duty>> GetAllByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
