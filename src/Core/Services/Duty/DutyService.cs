using Core.Data;
using Core.Interfaces;
using Core.Model.Users;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DutyService : IDutyService
    {
        private readonly IDutyRepository _dutyRepository;
        private readonly IUserRepository<IApplicationUser> _userRepository;

        public DutyService(IDutyRepository dutyRepository, IUserRepository<IApplicationUser> userRepository)
        {
            _dutyRepository = dutyRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Duty>> GetListAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if(user != null && user.FamilyId.HasValue)
            {
                return await _dutyRepository.GetByFamilyIdAsync(user.FamilyId.Value);
            }
            return null;
        }
    }
}
