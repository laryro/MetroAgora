using System;
using System.Web.Mvc;
using Resources;
using LF.MVC.Models;

namespace LF.MVC.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login(String backTo)
        {
            var model = new UsersLoginModel { BackTo = backTo };

            if (model.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UsersLoginModel model)
        {
            model.Login();

            if (!model.LoggedIn)
            {
                ModelState.AddModelError("", Errors.InvalidLogin);

                return View(model);
            }

            if (model.BackTo != null && model.BackTo.Contains(":"))
                model.BackTo = "";

            if (String.IsNullOrEmpty(model.BackTo))
                return RedirectToAction("Index", "Home");

            return Redirect(model.BackTo);
        }


        public ActionResult Logout(String backTo)
        {
            var model = new UsersLoginModel();

            model.Logout();

            if (backTo != null && backTo.Contains(":"))
                backTo = "";

            if (String.IsNullOrEmpty(backTo))
                return RedirectToAction("Index", "Home");

            return Redirect(backTo);
        }



        public ActionResult ChangePassword(Guid? id)
        {
            var model = new UsersChangePasswordModel(id);

            if (model.UserToChange == null)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(Guid? id, UsersChangePasswordModel model)
        {
            var errors = model.Validate(id);

            if (model.UserToChange == null)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }



        public ActionResult ForgotPassword()
        {
            var model = new UsersForgotPasswordModel();

            if (model.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ForgotPassword(UsersForgotPasswordModel model)
        {
            var sucess = model.SendRecoverLink();

            if (!sucess)
            {
                ModelState.AddModelError("", Errors.InvalidRecover);

                return View(model);
            }

            return RedirectToAction("ForgotPasswordSuccess");
        }

        public ActionResult ForgotPasswordSuccess()
        {
            return View(new BaseModel());
        }

        public ActionResult Create() {
            return View(new UsersCreateModel());
        }

        [HttpPost]
        public ActionResult Create(UsersCreateModel model)
        {
            model.Create();
            return RedirectToAction("CreateSuccess");
        }

        public ActionResult CreateSuccess()
        {
            return View(new BaseModel());
        }
    }
}
