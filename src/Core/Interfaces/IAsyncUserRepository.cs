using Core.Model;
using Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAsyncUserRepository<T> where T : IApplicationUser
    {
        Task SetUserFamilyIdNullAsync(string email, int familyId);
        Task<IApplicationUser> GetByEmailAsync(string email);
    }
}
