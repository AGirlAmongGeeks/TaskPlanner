using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using TaskPlanner.Interfaces;
using TaskPlanner.Models.FamilyViewModel;
using Microsoft.AspNetCore.Identity;
using Data.Models;
using TaskPlanner.Models.AccountViewModels;
using TaskPlanner.Services;

namespace TaskPlanner.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IFamilyService _familyService;
        private readonly IUserService _userService;
        private readonly IFamilyViewModelService _familyVMService;
        private readonly IEmailSender _emailSender;

        private readonly UserManager<ApplicationUser> _userManager;

        public FamilyController(IFamilyService familyService,
            IUserService userService,
                IFamilyViewModelService familyVMService,
                UserManager<ApplicationUser> userManager,
                IEmailSender emailSender
            )
        {
            _familyService = familyService;
            _userService = userService;
            _familyVMService = familyVMService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        #region Index()
        public async Task<IActionResult> Index()
        {
            var items = await _familyService.GetAllActiveAsync();
            var model = _familyVMService.CreateVMList(items);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FamilyListViewModel model)
        {
            if (!model.ShowAll)
            {
                return await Index();
            }

            var items = await _familyService.GetAllAsync();
            model = _familyVMService.CreateVMList(items, model);
            return View(model);
        } 
        #endregion

        #region Create()
        public ActionResult Create()
        {
            return View(new FamilyViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(FamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var family = new Core.Model.Family()
                    {
                        Name = model.Name,
                        IsActive = true
                    };

                    var result = await _familyService.CreateAsync(family);
                    return RedirectToAction("Index");
                }

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                return View("Edit", model);
            }
        }
        #endregion

        #region Edit()
        public async Task<ActionResult> Edit(int id)
        {
            var family = await _familyService.GetByIdWithMembersAsync(id);
            
            var model = _familyVMService.CreateViewModel(family);
            if (model != null)
            {
                return View("Edit", model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, FamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model?.Id == null)
                    {
                        return RedirectToAction("Index", "Family");
                    }

                    var family = await _familyService.GetByIdAsync(id);
                    if(family != null)
                    {
                        family.Name = model.Name;
                        family.IsActive = model.IsActive;
                    }
                   
                    await _familyService.UpdateAsync(family);

                    return RedirectToAction("Index");
                }

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                //TODO
                return View("Edit", model);
            }
        }
        #endregion

        #region CreateMember()
        public IActionResult CreateMember(int familyId)
        {
            var model = new CreateMemberViewModel();
            model.FamilyId = familyId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email  };

                var family = await _familyService.GetByIdAsync(model.FamilyId);
                if(family != null)
                {
                    user.Family = family;
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    return RedirectToAction("Edit", new { id = model.FamilyId });
                }
                else
                {
                    if (result.Errors != null && result.Errors.Count() > 0)
                    {
                        ViewData["Validation"] = String.Join(Environment.NewLine, result.Errors.Select(c => c.Description).ToArray());
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion

        #region RemoveMember()
        [HttpPost]
        public async Task<ActionResult> RemoveMember(int familyId, string email)
        {
            try
            {
                await _userService.RemoveMemberFromFamilyAsync(familyId, email);
                var family = await _familyService.GetByIdWithMembersAsync(familyId);

                var model = _familyVMService.CreateViewModel(family);
                if (model != null && model.Members != null)
                {
                    return PartialView("_Members", model.Members);
                }

                return Json(new { message = "No data!" });
            }
            catch (Exception ex)
            {
                //TODO
                return Json(new { message = "Error!" });
            }
        }
        #endregion

        #region DesactivateFamily()
        [HttpPost]
        public async Task<ActionResult> DesactivateFamily(int familyId)
        {
            try
            {
                await _familyService.DesactivateAsync(familyId);

                return await Edit(familyId);
            }
            catch (Exception ex)
            {
                //TODO
                return Json(new { message = "Error!" });
            }
        }
        #endregion
    }
}