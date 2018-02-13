using Core.Interfaces;
using Core.Model;
using Core.Model.Users;
using Core.Services;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Data;

namespace Data.Repositories
{
    public class EFUserRepository<T> : IUserRepository<T>, IAsyncUserRepository<T> where T : IApplicationUser
    {
        protected readonly ApplicationDbContext _dbContext;

        public EFUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GetByEmail()
        public IApplicationUser GetByEmail(string email)
        {
            return _dbContext.Users.Where(c => c.Email == email).FirstOrDefault();
        }

        public async Task<IApplicationUser> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.Where(c => c.Email == email).FirstOrDefaultAsync();
        }
        #endregion

        public IApplicationUser GetByName(string name)
        {
            return _dbContext.Users.Where(c => c.UserName == name).FirstOrDefault();
        }

        public async Task<IApplicationUser> GetByNameAsync(string name)
        {
            return await _dbContext.Users.Where(c => c.UserName == name).FirstOrDefaultAsync();
        }

        #region SetUserFamilyIdNull()
        public void SetUserFamilyIdNull(string email, int familyId)
        {
            var user = _dbContext.ApplicationUser.Where(c => c.Email == email && c.Family != null && c.FamilyId == familyId).FirstOrDefault();
            if (user != null)
            {
                user.FamilyId = (int?)null;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        public async Task SetUserFamilyIdNullAsync(string email, int familyId)
        {
            var user = await _dbContext.Users.Where(c => c.Email == email && c.Family != null && c.Family.Id == familyId).FirstOrDefaultAsync();
            if (user != null)
            {
                user.Family = null;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        } 
        #endregion
    }
}
