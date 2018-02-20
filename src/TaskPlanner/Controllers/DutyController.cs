using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services;

namespace TaskPlanner.Controllers
{
    [Route("[controller]/[action]")]
    public class DutyController : Controller
    {
        private readonly IDutyService _dutyService;

        public DutyController(IDutyService dutyService)
        {
            _dutyService = dutyService;      
        }

        public async Task<IActionResult> Index()
        {
            //TODO!!
            var duties = await _dutyService.GetListAsync(User.Identity.Name);
            return View();
        }
    }
}