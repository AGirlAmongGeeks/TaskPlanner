using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using TaskPlanner.Interfaces;
using TaskPlanner.Models.FamilyViewModel;

namespace TaskPlanner.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IFamilyService _familyService;
        private readonly IFamilyViewModelService _familyVMService;

        public FamilyController(IFamilyService familyService,
                IFamilyViewModelService familyVMService 
            )
        {
            _familyService = familyService;
            _familyVMService = familyVMService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _familyService.GetAllActiveAsync();
            var model = _familyVMService.CreateViewModelList(items);
            return View(model);
        }

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
            var family = await _familyService.GetByIdAsync(id);
            if (family != null)
            {
                var model = _familyVMService.CreateViewModel(family);
                return View("Create", model);
            }
            return RedirectToAction("Index", "Family");
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





        //[HttpGet]
        //public async Task<IActionResult> ChangePassword()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var hasPassword = await _userManager.HasPasswordAsync(user);
        //    if (!hasPassword)
        //    {
        //        return RedirectToAction(nameof(SetPassword));
        //    }

        //    var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //    if (!changePasswordResult.Succeeded)
        //    {
        //        AddErrors(changePasswordResult);
        //        return View(model);
        //    }

        //    await _signInManager.SignInAsync(user, isPersistent: false);
        //    _logger.LogInformation("User changed their password successfully.");
        //    StatusMessage = "Your password has been changed.";

        //    return RedirectToAction(nameof(ChangePassword));
        //}
    }
}