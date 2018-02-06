using Core.Interfaces;
using Core.Model;
using Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<IApplicationUser> _userRepository;

        public UserService(IUserRepository<IApplicationUser> familyRepository)
        {
            _userRepository = familyRepository;
        }
   
        public async Task RemoveMemberFromFamilyAsync(int familyId, string email)
        {
            _userRepository.SetUserFamilyIdNull(email, familyId);
        }
    }
}
