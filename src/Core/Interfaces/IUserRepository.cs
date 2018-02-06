using Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository<T> where T : IApplicationUser
    {
        void SetUserFamilyIdNull(string email, int familyId);
        IApplicationUser GetByEmail(string email);
    }
}
