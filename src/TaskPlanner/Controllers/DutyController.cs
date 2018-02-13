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

        public DutyController(IDutyService dutyService
            )
        {
            _dutyService = dutyService;      
        }

        public async Task<IActionResult> Index()
        {
            //if (_signInManager.IsSignedIn(HttpContext.User))
            //{
            //    return await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
            //}
            //TODO!!
            var duties = await _dutyService.GetListAsync(User.Identity.Name);
            //_dutyService.GetList()
            return View();
        }
    }
}