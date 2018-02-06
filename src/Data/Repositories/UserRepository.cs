using Core.Interfaces;
using Core.Model.Users;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Data;

namespace Data.Repositories
{
    public class UserRepository : EFUserRepository<ApplicationUser>, IUserRepository<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
