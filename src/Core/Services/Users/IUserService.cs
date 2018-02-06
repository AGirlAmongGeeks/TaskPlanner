using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task RemoveMemberFromFamilyAsync(int familyId, string memberEmail);
    }
}
