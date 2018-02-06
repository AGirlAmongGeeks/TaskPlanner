using Core.Data;
using Core.Interfaces;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DutyService : IDutyService
    {
        private readonly IAsyncRepository<Duty> _dutyRepository;

        public DutyService(IAsyncRepository<Duty> dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }
    }
}
