using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDutyRepository
    {
        //Task<List<Duty>> GetAllByUserId(int userId);
        Task<List<Duty>> GetByFamilyIdAsync(int familyId);
    }
}
